namespace WMS.Application.Commands.InventoryReceiptCommands.InventoryReceipts
{
    public class CreateInventoryReceiptCommandHandler : IRequestHandler<CreateInventoryReceiptCommand, bool>
    {
        private readonly ReceiptStatus completedStatus = ReceiptStatus.Completed;
        private readonly LotStatus available = LotStatus.Available;
        private readonly LotStatus done = LotStatus.Done;

        private readonly IInventoryReceiptRepository _inventoryReceiptRepository;
        private readonly IInventoryReceiptEntryRepository _inventoryReceiptEntryRepository;
        private readonly IReceiptLotRepository _receiptLotRepository;
        private readonly IReceiptSubLotRepository _receiptSubLotRepository;
        private readonly IMaterialLotRepository _materialLotRepository;
        private readonly IMaterialSubLotRepository _materialSubLotRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IWarehouseRepository _warehouseRepository;

        public CreateInventoryReceiptCommandHandler(IInventoryReceiptRepository inventoryReceiptRepository, IInventoryReceiptEntryRepository inventoryReceiptEntryRepository, IReceiptLotRepository receiptLotRepository, IReceiptSubLotRepository receiptSubLotRepository, IMaterialLotRepository materialLotRepository, IMaterialSubLotRepository materialSubLotRepository, ISupplierRepository supplierRepository, IPersonRepository personRepository, IWarehouseRepository warehouseRepository)
        {
            _inventoryReceiptRepository = inventoryReceiptRepository;
            _inventoryReceiptEntryRepository = inventoryReceiptEntryRepository;
            _receiptLotRepository = receiptLotRepository;
            _receiptSubLotRepository = receiptSubLotRepository;
            _materialLotRepository = materialLotRepository;
            _materialSubLotRepository = materialSubLotRepository;
            _supplierRepository = supplierRepository;
            _personRepository = personRepository;
            _warehouseRepository = warehouseRepository;
        }

        public async Task<bool> Handle(CreateInventoryReceiptCommand request, CancellationToken cancellationToken)
        {
            var inventoryReceipt = await _inventoryReceiptRepository.GetByIdAsync(request.InventoryReceiptId);
            if(inventoryReceipt != null)
            {
                throw new DuplicateRecordException(nameof(InventoryReceipt),request.InventoryReceiptId);
            }

            var supplier = await _supplierRepository.GetByIdAsync(request.SupplierId);
            if(supplier == null)
            {
                throw new EntityNotFoundException(nameof(Supplier),request.SupplierId);
            }

            var person = await _personRepository.GetPersonById(request.PersonId);
            if(person == null)
            {
                throw new EntityNotFoundException(nameof(Person),request.PersonId);
            }

            var warehouse = await _warehouseRepository.GetWarehouseById(request.WarehouseId);
            if(warehouse == null)
            {
                throw new EntityNotFoundException(nameof(Warehouse),request.WarehouseId);
            }

            if(!Enum.TryParse<ReceiptStatus>(request.ReceiptStatus,out var Status))
            {
                throw new Exception($"Invalid receipt status: {request.ReceiptStatus}");
            }

            var newInventoryReceipt = new InventoryReceipt(inventoryReceiptId: request.InventoryReceiptId,
                                                        receiptDate: request.ReceiptDate,
                                                        receiptStatus: Status,
                                                        supplierId: request.SupplierId,
                                                        personId: request.PersonId,
                                                        warehouseId: request.WarehouseId);
            
            foreach(var entry in request.Entries)
            {
                var Entry = await _inventoryReceiptEntryRepository.GetById(entry.InventoryReceiptEntryId);
                if(Entry != null)
                {
                    throw new DuplicateRecordException(nameof(InventoryReceiptEntry),entry.InventoryReceiptEntryId);
                }

                var newEntry = new InventoryReceiptEntry(inventoryReceiptEntryId: entry.InventoryReceiptEntryId,
                                                         purchaseOrderNumber: entry.PurchaseOrderNumber,
                                                         materialId: entry.MaterialId,
                                                         note: entry.Note,
                                                         lotNumber: entry.LotNumber,
                                                         inventoryReceiptId: entry.InventoryReceiptId);

                var receiptLot = await _receiptLotRepository.GetById(entry.ReceiptLot.ReceiptLotId);
                if(receiptLot != null)
                {
                    throw new DuplicateRecordException(nameof(ReceiptLot),entry.ReceiptLot.ReceiptLotId);
                }

                if (!Enum.TryParse<LotStatus>(entry.ReceiptLot.ReceiptLotStatus, out var LotStatus))
                {
                    throw new Exception($"Invalid receiptLot status: {entry.ReceiptLot.ReceiptLotStatus}");
                }

                var newReceiptLot = new ReceiptLot(receiptLotId: entry.ReceiptLot.ReceiptLotId,
                                                   importedQuantity: entry.ReceiptLot.ImportedQuantity,
                                                   receiptLotStatus: LotStatus,
                                                   inventoryReceiptEntryId: entry.InventoryReceiptEntryId);

                foreach(var subLot in entry.ReceiptLot.ReceiptSublots)
                {

                    var SubLot = await _receiptSubLotRepository.GetByIdAsync(subLot.ReceiptSublotId);
                    if(SubLot != null)
                    {
                        throw new DuplicateRecordException(nameof(ReceiptSublot),subLot.ReceiptSublotId);
                    }

                    if (!Enum.TryParse<LotStatus>(subLot.SubLotStatus, out var SubLotStatus))
                    {
                        throw new Exception($"Invalid receiptSubLot status: {subLot.SubLotStatus}");
                    }
                    if (!Enum.TryParse<UnitOfMeasure>(subLot.UnitOfMeasure, out var unitOfMeasures))
                    {
                        throw new Exception($"Invalid UnitOfMeasure status: {subLot.UnitOfMeasure}");
                    }

                    var newReceiptSubLot = new ReceiptSublot(receiptSublotId: subLot.ReceiptSublotId,
                                                      importedQuantity: subLot.ImportedQuantity,
                                                      subLotStatus: SubLotStatus,
                                                      unitOfMeasure: unitOfMeasures,
                                                      locationId: subLot.LocationId,
                                                      receiptLotId: subLot.receiptLotId);

                    newReceiptLot.AddSublot(newReceiptSubLot);

                }

                newEntry.receiptLot = newReceiptLot;

                newInventoryReceipt.AddEntry(newEntry);
            }

            var newMaterialLots = new List<MaterialLot>();
            if (newInventoryReceipt.receiptStatus == completedStatus)
            {
                foreach(var entry in newInventoryReceipt.entries)
                {
                    if (entry.receiptLot.receiptLotStatus == done)
                    {
                        var materialLot = await _materialLotRepository.GetMaterialLotById(entry.receiptLot.receiptLotId);
                        if(materialLot != null)
                        {
                            throw new DuplicateRecordException(nameof(MaterialLot),entry.receiptLot.receiptLotId);
                        }

                        var newMaterialLot = new MaterialLot(lotNumber: entry.receiptLot.receiptLotId,
                                                             lotStatus: available,
                                                             materialId:entry.materialId,
                                                             exisitingQuantity: entry.receiptLot.importedQuantity);

                        foreach(var sublot in entry.receiptLot.receiptSublots)
                        {
                            var existedSublot = await _materialSubLotRepository.GetByIdAsync(sublot.receiptSublotId);
                            if(existedSublot != null)
                            {
                                throw new DuplicateRecordException(nameof(MaterialSubLot),sublot.receiptSublotId);
                            }

                            var newSubLot = new MaterialSubLot(subLotId: sublot.receiptSublotId,
                                                               subLotStatus: available,
                                                               existingQuality: sublot.importedQuantity,
                                                               unitOfMeasure: sublot.unitOfMeasure,
                                                               locationId: sublot.locationId,
                                                               lotNumber: sublot.receiptLotId);

                            newMaterialLot.AddSubLot(newSubLot);
                        }

                        newMaterialLots.Add(newMaterialLot);
                    }
                    
                }

                newInventoryReceipt.Confirm(newMaterialLots, newInventoryReceipt);

            }

            _inventoryReceiptRepository.Create(newInventoryReceipt);
            
            return await _inventoryReceiptRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        }
    }
}
