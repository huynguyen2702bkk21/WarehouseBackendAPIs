namespace WMS.Application.Commands.InventoryReceiptCommands.InventoryReceiptEntries
{
    public class CreateInventoryReceiptEntryCommandHandler : IRequestHandler<CreateInventoryReceiptEntryCommand, bool>
    {
        private readonly IInventoryReceiptRepository _inventoryReceiptRepository;
        private readonly IInventoryReceiptEntryRepository _inventoryReceiptEntryRepository;
        private readonly IReceiptLotRepository _receiptLotRepository;
        private readonly IReceiptSubLotRepository _receiptSubLotRepository;

        public CreateInventoryReceiptEntryCommandHandler(IInventoryReceiptRepository inventoryReceiptRepository, IInventoryReceiptEntryRepository inventoryReceiptEntryRepository, IReceiptLotRepository receiptLotRepository, IReceiptSubLotRepository receiptSubLotRepository)
        {
            _inventoryReceiptRepository = inventoryReceiptRepository;
            _inventoryReceiptEntryRepository = inventoryReceiptEntryRepository;
            _receiptLotRepository = receiptLotRepository;
            _receiptSubLotRepository = receiptSubLotRepository;
        }

        public async Task<bool> Handle(CreateInventoryReceiptEntryCommand request, CancellationToken cancellationToken)
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

            var Entry = await _inventoryReceiptEntryRepository.GetById(request.InventoryReceiptEntryId);
            if (Entry != null)
            {
                throw new DuplicateRecordException(nameof(InventoryReceiptEntry), request.InventoryReceiptEntryId);
            }

            var newEntry = await CreateEntry(request);

            inventoryReceipt.AddEntry(newEntry);

            return await _inventoryReceiptRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

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





    }
}
