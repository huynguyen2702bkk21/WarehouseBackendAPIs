namespace WMS.Application.Commands.InventoryReceiptCommands.InventoryReceipts
{
    public class DeleteInventoryReceiptCommandHandler : IRequestHandler<DeleteInventoryReceiptCommand, bool>
    {
        private readonly IInventoryReceiptRepository _inventoryReceiptRepository;

        public DeleteInventoryReceiptCommandHandler(IInventoryReceiptRepository inventoryReceiptRepository)
        {
            _inventoryReceiptRepository = inventoryReceiptRepository;
        }

        public async Task<bool> Handle(DeleteInventoryReceiptCommand request, CancellationToken cancellationToken)
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

            _inventoryReceiptRepository.Delete(inventoryReceipt);

            return await _inventoryReceiptRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }


    }
}
