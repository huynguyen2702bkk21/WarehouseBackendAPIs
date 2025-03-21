namespace WMS.Application.Commands.InventoryReceiptCommands.ReceiptLots
{
    public class UpdateReceiptLotStatusCommand : IRequest<bool>
    {
        public string InventoryReceiptId { get; set; }
        public string InventoryReceiptEntryId { get; set; }
        public string ReceiptLotId { get; set; }
        public string ReceiptLotStatus { get; set; }

        public UpdateReceiptLotStatusCommand(string inventoryReceiptId, string inventoryReceiptEntryId, string receiptLotId, string receiptLotStatus)
        {
            InventoryReceiptId = inventoryReceiptId;
            InventoryReceiptEntryId = inventoryReceiptEntryId;
            ReceiptLotId = receiptLotId;
            ReceiptLotStatus = receiptLotStatus;
        }
    }
}
