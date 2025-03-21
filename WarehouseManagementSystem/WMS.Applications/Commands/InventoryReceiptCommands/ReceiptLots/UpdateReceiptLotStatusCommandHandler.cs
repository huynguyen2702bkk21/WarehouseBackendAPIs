namespace WMS.Application.Commands.InventoryReceiptCommands.ReceiptLots
{
    public class UpdateReceiptLotStatusCommandHandler : IRequestHandler<UpdateReceiptLotStatusCommand,bool>
    {
        private readonly IInventoryReceiptRepository _inventoryReceiptRepository;

        public UpdateReceiptLotStatusCommandHandler(IInventoryReceiptRepository inventoryReceiptRepository)
        {
            _inventoryReceiptRepository = inventoryReceiptRepository;
        }

        public async Task<bool> Handle(UpdateReceiptLotStatusCommand request, CancellationToken cancellationToken)
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

            var inventoryReceiptEntry = inventoryReceipt.entries
                .FirstOrDefault(x => x.inventoryReceiptEntryId == request.InventoryReceiptEntryId);

            if (inventoryReceiptEntry == null)
            {
                throw new EntityNotFoundException(nameof(InventoryReceiptEntry), request.InventoryReceiptEntryId);
            }

            if (inventoryReceiptEntry.receiptLot == null)
            {
                throw new EntityNotFoundException(nameof(ReceiptLot), request.ReceiptLotId);
            }

            if (!Enum.TryParse(request.ReceiptLotStatus, true, out LotStatus lotStatus))
            {
                throw new ArgumentException($"Invalid receiptLot status: {request.ReceiptLotStatus}");
            }

            inventoryReceiptEntry.receiptLot.Update(lotStatus);

            return await _inventoryReceiptRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }



    }
}
