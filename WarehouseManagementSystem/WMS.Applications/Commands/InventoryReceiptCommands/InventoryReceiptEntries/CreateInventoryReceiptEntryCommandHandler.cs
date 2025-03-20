namespace WMS.Application.Commands.InventoryReceiptCommands.InventoryReceiptEntries
{
    public class CreateInventoryReceiptEntryCommandHandler : IRequestHandler<CreateInventoryReceiptEntryCommand, bool>
    {
        private readonly IInventoryReceiptRepository _inventoryReceiptRepository;
        private readonly IInventoryReceiptEntryRepository _inventoryReceiptEntryRepository;
        private readonly IReceiptServices _receiptServices;

        public CreateInventoryReceiptEntryCommandHandler(IInventoryReceiptRepository inventoryReceiptRepository, IInventoryReceiptEntryRepository inventoryReceiptEntryRepository, IReceiptServices receiptServices)
        {
            _inventoryReceiptRepository = inventoryReceiptRepository;
            _inventoryReceiptEntryRepository = inventoryReceiptEntryRepository;
            _receiptServices = receiptServices;
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

            var newEntry = await _receiptServices.CreateEntry(request);

            inventoryReceipt.AddEntry(newEntry);

            return await _inventoryReceiptRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        }

    }
}
