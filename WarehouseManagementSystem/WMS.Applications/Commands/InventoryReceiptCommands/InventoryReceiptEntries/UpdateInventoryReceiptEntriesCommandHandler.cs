namespace WMS.Application.Commands.InventoryReceiptCommands.InventoryReceiptEntries
{
    public class UpdateInventoryReceiptEntriesCommandHandler : IRequestHandler<UpdateInventoryReceiptEntriesCommand, bool>
    {
        private readonly IInventoryReceiptRepository _inventoryReceiptRepository;
        private readonly IReceiptServices _receiptServices;

        public UpdateInventoryReceiptEntriesCommandHandler(IInventoryReceiptRepository inventoryReceiptRepository, IReceiptServices receiptServices)
        {
            _inventoryReceiptRepository = inventoryReceiptRepository;
            _receiptServices = receiptServices;
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

            await _receiptServices.UpdateReceiptEntries(request);

            await _receiptServices.AddReceiptLotToMaterialLot(inventoryReceipt);

            return await _inventoryReceiptRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        }

    }
}
