using Azure.Core;

namespace WMS.Application.Commands.InventoryReceiptCommands.InventoryReceipts
{
    public class UpdateInventoryReceiptEntriesCommandHandler : IRequestHandler<UpdateInventoryReceiptEntriesCommand,bool>
    {
        private readonly IInventoryReceiptRepository _inventoryReceiptRepository;
        private readonly IInventoryReceiptEntryRepository _inventoryReceiptEntryRepository;
        private readonly IReceiptLotRepository _receiptLotRepository;
        private readonly IMaterialLotRepository _materialLotRepository;
        private readonly IMaterialSubLotRepository _materialSubLotRepository;
        private readonly IReceiptSubLotRepository _receiptSubLotRepository;

        public UpdateInventoryReceiptEntriesCommandHandler(IInventoryReceiptRepository inventoryReceiptRepository, IInventoryReceiptEntryRepository inventoryReceiptEntryRepository, IReceiptLotRepository receiptLotRepository, IMaterialLotRepository materialLotRepository, IMaterialSubLotRepository materialSubLotRepository, IReceiptSubLotRepository receiptSubLotRepository)
        {
            _inventoryReceiptRepository = inventoryReceiptRepository;
            _inventoryReceiptEntryRepository = inventoryReceiptEntryRepository;
            _receiptLotRepository = receiptLotRepository;
            _materialLotRepository = materialLotRepository;
            _materialSubLotRepository = materialSubLotRepository;
            _receiptSubLotRepository = receiptSubLotRepository;
        }

        public async Task<bool> Handle(UpdateInventoryReceiptEntriesCommand request, CancellationToken cancellationToken)
        {
            var inventoryReceipt = await _inventoryReceiptRepository.GetByIdAsync(request.InventoryReceiptId);
            if (inventoryReceipt == null)
            {
                throw new EntityNotFoundException(nameof(InventoryReceipt), request.InventoryReceiptId);
            }
            if (inventoryReceipt.receiptStatus == ReceiptStatus.Completed)
            {
                throw new Exception("The Receipt has been saved");
            }

            await UpdateReceiptEntries(request);

            await AddToMaterialLot(inventoryReceipt);

            return await _inventoryReceiptRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);   

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




    }
}
