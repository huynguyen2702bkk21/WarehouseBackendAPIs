namespace WMS.Application.Commands.InventoryReceiptCommands.InventoryReceipts
{
    public class RefreshInventoryReceiptStatusCommandHandler : IRequestHandler<RefreshInventoryReceiptStatusCommand,bool>
    {
        private readonly IInventoryReceiptRepository _inventoryReceiptRepository;
        private readonly IReceiptServices _receiptServices;

        public RefreshInventoryReceiptStatusCommandHandler(IInventoryReceiptRepository inventoryReceiptRepository, IReceiptServices receiptServices)
        {
            _inventoryReceiptRepository = inventoryReceiptRepository;
            _receiptServices = receiptServices;
        }

        public async Task<bool> Handle(RefreshInventoryReceiptStatusCommand request, CancellationToken cancellationToken)
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

            await _receiptServices.AddToMaterialLot(inventoryReceipt);

            return await _inventoryReceiptRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }



    }
}
