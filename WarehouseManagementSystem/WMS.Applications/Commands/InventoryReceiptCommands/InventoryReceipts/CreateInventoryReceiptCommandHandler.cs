namespace WMS.Application.Commands.InventoryReceiptCommands.InventoryReceipts
{
    public class CreateInventoryReceiptCommandHandler : IRequestHandler<CreateInventoryReceiptCommand, bool>
    {
        private readonly IInventoryReceiptRepository _inventoryReceiptRepository;
        private readonly IInventoryReceiptEntryRepository _inventoryReceiptEntryRepository;
        private readonly IReceiptLotRepository _receiptLotRepository;
        private readonly IReceiptSubLotRepository _receiptSubLotRepository;
        private readonly IMaterialLotRepository _materialLotRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IWarehouseRepository _warehouseRepository;

        public CreateInventoryReceiptCommandHandler(IInventoryReceiptRepository inventoryReceiptRepository, IInventoryReceiptEntryRepository inventoryReceiptEntryRepository, IReceiptLotRepository receiptLotRepository, IReceiptSubLotRepository receiptSubLotRepository, IMaterialLotRepository materialLotRepository, ISupplierRepository supplierRepository, IPersonRepository personRepository, IWarehouseRepository warehouseRepository)
        {
            _inventoryReceiptRepository = inventoryReceiptRepository;
            _inventoryReceiptEntryRepository = inventoryReceiptEntryRepository;
            _receiptLotRepository = receiptLotRepository;
            _receiptSubLotRepository = receiptSubLotRepository;
            _materialLotRepository = materialLotRepository;
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

                var newMaterialLot = new MaterialLot(lotNumber: entry.ReceiptLot.ReceiptLotId,
                                                     lotStatus: LotStatus,
                                                     materialId: entry.MaterialId,
                                                     exisitingQuantity: entry.ReceiptLot.ImportedQuantity);

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

                    var newMaterialSubLot = new MaterialSubLot(subLotId: subLot.ReceiptSublotId,
                                                               subLotStatus: SubLotStatus,
                                                               existingQuality: subLot.ImportedQuantity,
                                                               unitOfMeasure: unitOfMeasures,
                                                               locationId: subLot.LocationId,
                                                               lotNumber: subLot.receiptLotId);

                    newMaterialLot.AddSubLot(newMaterialSubLot);
                }

                _materialLotRepository.Create(newMaterialLot);

                newEntry.receiptLot = newReceiptLot;

                newInventoryReceipt.AddEntry(newEntry);
            }

            _inventoryReceiptRepository.Create(newInventoryReceipt);
            
            return await _inventoryReceiptRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        }
    }
}
