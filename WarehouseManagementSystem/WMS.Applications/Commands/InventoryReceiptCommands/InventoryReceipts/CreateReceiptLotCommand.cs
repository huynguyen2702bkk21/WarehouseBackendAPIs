namespace WMS.Application.Commands.InventoryReceiptCommands.InventoryReceipts
{
    public class CreateReceiptLotCommand : IRequest<bool>
    {
        public string ReceiptLotId { get; set; }
        public double ImportedQuantity { get; set; }
        public string ReceiptLotStatus { get; set; }
        public string InventoryReceiptEntryId { get; set; }
        public List<CreateReceiptSubLotCommand> ReceiptSublots { get; set; }

        public CreateReceiptLotCommand(string receiptLotId, double importedQuantity, string receiptLotStatus, string inventoryReceiptEntryId, List<CreateReceiptSubLotCommand> receiptSublots)
        {
            ReceiptLotId = receiptLotId;
            ImportedQuantity = importedQuantity;
            ReceiptLotStatus = receiptLotStatus;
            InventoryReceiptEntryId = inventoryReceiptEntryId;
            ReceiptSublots = receiptSublots;
        }
    }
}
