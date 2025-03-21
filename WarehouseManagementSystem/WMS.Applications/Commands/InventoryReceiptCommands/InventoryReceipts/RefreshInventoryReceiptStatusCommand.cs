namespace WMS.Application.Commands.InventoryReceiptCommands.InventoryReceipts
{
    public class RefreshInventoryReceiptStatusCommand : IRequest<bool>
    {
        public string InventoryReceiptId { get; set; }

        public RefreshInventoryReceiptStatusCommand(string inventoryReceiptId)
        {
            InventoryReceiptId = inventoryReceiptId;
        }
    }
}
