namespace WMS.Application.Commands.InventoryReceiptCommands.InventoryReceipts
{
    public class UpdateInventoryReceiptCommandHandler : IRequestHandler<UpdateInventoryReceiptCommand, bool>
    {
        private readonly IInventoryReceiptRepository _inventoryReceiptRepository;

        public UpdateInventoryReceiptCommandHandler(IInventoryReceiptRepository inventoryReceiptRepository)
        {
            _inventoryReceiptRepository = inventoryReceiptRepository;
        }

        public async Task<bool> Handle(UpdateInventoryReceiptCommand request, CancellationToken cancellationToken)
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

            inventoryReceipt.Update(supplierId: request.SupplierId,
                                    personId: request.PersonId,
                                    warehouseId: request.WarehouseId);

            return await _inventoryReceiptRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }




    }
}
