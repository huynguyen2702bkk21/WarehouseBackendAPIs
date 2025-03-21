namespace WMS.Application.Commands.InventoryReceiptCommands.InventoryReceipts
{
    public class DeleteInventoryReceiptCommand : IRequest<bool>
    {
        public string InventoryReceiptId { get; set; }

        public DeleteInventoryReceiptCommand(string inventoryReceiptId)
        {
            InventoryReceiptId = inventoryReceiptId;
        }
    }
}
