namespace WMS.Application.Commands.InventoryReceiptCommands.InventoryReceiptServices
{
    public class ReceiptServices : IReceiptServices
    {
        private readonly IMaterialLotRepository _materialLotRepository;
        private readonly IMaterialSubLotRepository _materialSubLotRepository;
        private readonly IInventoryReceiptEntryRepository _inventoryReceiptEntryRepository;
        private readonly IReceiptLotRepository _receiptLotRepository;
        private readonly IReceiptSubLotRepository _receiptSubLotRepository;

        public ReceiptServices(IMaterialLotRepository materialLotRepository, IMaterialSubLotRepository materialSubLotRepository, IInventoryReceiptEntryRepository inventoryReceiptEntryRepository, IReceiptLotRepository receiptLotRepository, IReceiptSubLotRepository receiptSubLotRepository)
        {
            _materialLotRepository = materialLotRepository;
            _materialSubLotRepository = materialSubLotRepository;
            _inventoryReceiptEntryRepository = inventoryReceiptEntryRepository;
            _receiptLotRepository = receiptLotRepository;
            _receiptSubLotRepository = receiptSubLotRepository;
        }

        private static DateTime GetVietnamTime()
        {
            return TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time"));
        }

        public async Task AddReceiptLotToMaterialLot(InventoryReceipt newInventoryReceipt)
        {
            var newMaterialLots = new List<MaterialLot>();
            var inventoryReceiptStatus = ReceiptStatus.Completed;
            foreach (var entry in newInventoryReceipt.entries)
            {
                if (entry.receiptLot.receiptLotStatus != LotStatus.Done)
                {
                    inventoryReceiptStatus = ReceiptStatus.Pending;
                }

                var materialLot = await _materialLotRepository.GetMaterialLotById(entry.receiptLot.receiptLotId);
                if (materialLot != null)
                {
                    throw new DuplicateRecordException(nameof(MaterialLot), entry.receiptLot.receiptLotId);
                }

                var newMaterialLot = new MaterialLot(lotNumber: entry.receiptLot.receiptLotId,
                                                     lotStatus: LotStatus.Available,
                                                     materialId: entry.materialId,
                                                     exisitingQuantity: entry.receiptLot.importedQuantity);

                var receiptSublots = await _receiptSubLotRepository.GetSublotsByLotId(entry.receiptLot.receiptLotId);

                foreach (var sublot in receiptSublots)
                {
                    var existedSublot = await _materialSubLotRepository.GetByIdAsync(sublot.receiptSublotId);
                    if (existedSublot != null)
                    {
                        throw new DuplicateRecordException(nameof(MaterialSubLot), sublot.receiptSublotId);
                    }

                    var newSubLot = new MaterialSubLot(subLotId: sublot.receiptSublotId,
                                                       subLotStatus: LotStatus.Available,
                                                       existingQuality: sublot.importedQuantity,
                                                       unitOfMeasure: sublot.unitOfMeasure,
                                                       locationId: sublot.locationId,
                                                       lotNumber: sublot.receiptLotId);

                    newMaterialLot.AddSubLot(newSubLot);
                }
                newMaterialLots.Add(newMaterialLot);
            }

            if (inventoryReceiptStatus == ReceiptStatus.Completed)
            {
                newInventoryReceipt.Confirm(newMaterialLots, newInventoryReceipt);
                newInventoryReceipt.receiptStatus = inventoryReceiptStatus;
            }
            else
            {
                newInventoryReceipt.receiptStatus = inventoryReceiptStatus;
            }

        }

        public async Task AddToMaterialLot(InventoryReceipt newInventoryReceipt)
        {
            var newMaterialLots = new List<MaterialLot>();
            var inventoryReceiptStatus = ReceiptStatus.Completed;
            foreach (var entry in newInventoryReceipt.entries)
            {
                if (entry.receiptLot.receiptLotStatus != LotStatus.Done)
                {
                    inventoryReceiptStatus = ReceiptStatus.Pending;
                }

                var materialLot = await _materialLotRepository.GetMaterialLotById(entry.receiptLot.receiptLotId);
                if (materialLot != null)
                {
                    throw new DuplicateRecordException(nameof(MaterialLot), entry.receiptLot.receiptLotId);
                }

                var newMaterialLot = new MaterialLot(lotNumber: entry.receiptLot.receiptLotId,
                                                     lotStatus: LotStatus.Available,
                                                     materialId: entry.materialId,
                                                     exisitingQuantity: entry.receiptLot.importedQuantity);

                foreach (var sublot in entry.receiptLot.receiptSublots)
                {
                    var existedSublot = await _materialSubLotRepository.GetByIdAsync(sublot.receiptSublotId);
                    if (existedSublot != null)
                    {
                        throw new DuplicateRecordException(nameof(MaterialSubLot), sublot.receiptSublotId);
                    }

                    var newSubLot = new MaterialSubLot(subLotId: sublot.receiptSublotId,
                                                       subLotStatus: LotStatus.Available,
                                                       existingQuality: sublot.importedQuantity,
                                                       unitOfMeasure: sublot.unitOfMeasure,
                                                       locationId: sublot.locationId,
                                                       lotNumber: sublot.receiptLotId);

                    newMaterialLot.AddSubLot(newSubLot);
                }
                newMaterialLots.Add(newMaterialLot);
            }

            if (inventoryReceiptStatus == ReceiptStatus.Completed)
            {
                newInventoryReceipt.Confirm(newMaterialLots, newInventoryReceipt);
                newInventoryReceipt.receiptStatus = inventoryReceiptStatus;
            }
            else
            {
                newInventoryReceipt.receiptStatus = inventoryReceiptStatus;
            }

        }

        public async Task<InventoryReceiptEntry> CreateEntry(CreateInventoryReceiptEntryCommand request)
        {
            var newEntry = new InventoryReceiptEntry(inventoryReceiptEntryId: request.InventoryReceiptEntryId,
                                         purchaseOrderNumber: request.PurchaseOrderNumber,
                                         materialId: request.MaterialId,
                                         note: request.Note,
                                         lotNumber: request.LotNumber,
                                         inventoryReceiptId: request.InventoryReceiptId);

            var receiptLot = await _receiptLotRepository.GetById(request.ReceiptLot.ReceiptLotId);
            if (receiptLot != null)
            {
                throw new DuplicateRecordException(nameof(ReceiptLot), request.ReceiptLot.ReceiptLotId);
            }

            if (!Enum.TryParse<LotStatus>(request.ReceiptLot.ReceiptLotStatus, out var LotStatus))
            {
                throw new Exception($"Invalid receiptLot status: {request.ReceiptLot.ReceiptLotStatus}");
            }

            var newReceiptLot = new ReceiptLot(receiptLotId: request.ReceiptLot.ReceiptLotId,
                                               importedQuantity: request.ReceiptLot.ImportedQuantity,
                                               receiptLotStatus: LotStatus,
                                               inventoryReceiptEntryId: request.InventoryReceiptEntryId);

            foreach (var subLot in request.ReceiptLot.ReceiptSublots)
            {

                var SubLot = await _receiptSubLotRepository.GetByIdAsync(subLot.ReceiptSublotId);
                if (SubLot != null)
                {
                    throw new DuplicateRecordException(nameof(ReceiptSublot), subLot.ReceiptSublotId);
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

            return newEntry;

        }

        public async Task<InventoryReceipt> CreateNewInventoryReceipt(CreateInventoryReceiptCommand request)
        {
            if (!Enum.TryParse<ReceiptStatus>(request.ReceiptStatus, out var Status))
            {
                throw new Exception($"Invalid receipt status: {request.ReceiptStatus}");
            }

            var newInventoryReceipt = new InventoryReceipt(inventoryReceiptId: request.InventoryReceiptId,
                                                           receiptDate: GetVietnamTime(),
                                                           receiptStatus: Status,
                                                           supplierId: request.SupplierId,
                                                           personId: request.PersonId,
                                                           warehouseId: request.WarehouseId);

            foreach (var entry in request.Entries)
            {
                var Entry = await _inventoryReceiptEntryRepository.GetById(entry.InventoryReceiptEntryId);
                if (Entry != null)
                {
                    throw new DuplicateRecordException(nameof(InventoryReceiptEntry), entry.InventoryReceiptEntryId);
                }

                var newEntry = new InventoryReceiptEntry(inventoryReceiptEntryId: entry.InventoryReceiptEntryId,
                                                         purchaseOrderNumber: entry.PurchaseOrderNumber,
                                                         materialId: entry.MaterialId,
                                                         note: entry.Note,
                                                         lotNumber: entry.LotNumber,
                                                         inventoryReceiptId: entry.InventoryReceiptId);

                var receiptLot = await _receiptLotRepository.GetById(entry.ReceiptLot.ReceiptLotId);
                if (receiptLot != null)
                {
                    throw new DuplicateRecordException(nameof(ReceiptLot), entry.ReceiptLot.ReceiptLotId);
                }

                if (!Enum.TryParse<LotStatus>(entry.ReceiptLot.ReceiptLotStatus, out var LotStatus))
                {
                    throw new Exception($"Invalid receiptLot status: {entry.ReceiptLot.ReceiptLotStatus}");
                }

                var newReceiptLot = new ReceiptLot(receiptLotId: entry.ReceiptLot.ReceiptLotId,
                                                   importedQuantity: entry.ReceiptLot.ImportedQuantity,
                                                   receiptLotStatus: LotStatus,
                                                   inventoryReceiptEntryId: entry.InventoryReceiptEntryId);

                foreach (var subLot in entry.ReceiptLot.ReceiptSublots)
                {

                    var SubLot = await _receiptSubLotRepository.GetByIdAsync(subLot.ReceiptSublotId);
                    if (SubLot != null)
                    {
                        throw new DuplicateRecordException(nameof(ReceiptSublot), subLot.ReceiptSublotId);
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

            return newInventoryReceipt;

        }

        public async Task UpdateReceiptEntries(UpdateInventoryReceiptEntriesCommand request)
        {
            foreach (var entry in request.Entries)
            {
                var inventoryReceiptEntry = await _inventoryReceiptEntryRepository.GetById(entry.InventoryReceiptEntryId);
                if (inventoryReceiptEntry == null)
                {
                    throw new EntityNotFoundException(nameof(InventoryReceiptEntry), entry.InventoryReceiptEntryId);
                }

                inventoryReceiptEntry.Update(entry.PurchaseOrderNumber);

                var receiptLot = await _receiptLotRepository.GetByIdAsnc(entry.ReceiptLot.ReceiptLotId);
                if (receiptLot == null)
                {
                    throw new EntityNotFoundException(nameof(ReceiptLot), entry.ReceiptLot.ReceiptLotId);
                }
                if (!Enum.TryParse<LotStatus>(entry.ReceiptLot.ReceiptLotStatus, out var receiptLotStatus))
                {
                    throw new Exception($"Invalid LotStatus status: {entry.ReceiptLot.ReceiptLotStatus}");
                }
                receiptLot.Update(entry.ReceiptLot.ImportedQuantity, receiptLotStatus);

                foreach (var sublot in entry.ReceiptLot.ReceiptSublots)
                {
                    var receiptSubLot = await _receiptSubLotRepository.GetByIdAsync(sublot.ReceiptSublotId);
                    if (receiptSubLot == null)
                    {
                        throw new EntityNotFoundException(nameof(ReceiptSublot), sublot.ReceiptSublotId);
                    }
                    if (!Enum.TryParse<LotStatus>(sublot.SubLotStatus, out var sublotStatus))
                    {
                        throw new Exception($"Invalid SubLot status: {entry.ReceiptLot.ReceiptLotStatus}");
                    }
                    if (!Enum.TryParse<UnitOfMeasure>(sublot.UnitOfMeasure, out var subLotUnitOfMeasure))
                    {
                        throw new Exception($"Invalid UnitOfMeasure status: {entry.ReceiptLot.ReceiptLotStatus}");
                    }

                    receiptSubLot.Update(importedQuantity: sublot.ImportedQuantity,
                                         subLotStatus: sublotStatus,
                                         unitOfMeasure: subLotUnitOfMeasure,
                                         locationId: sublot.LocationId);

                }

            }
        }
    }
}
