namespace WMS.Application.Commands.InventoryReceiptCommands.InventoryReceipts
{
    public class CreateReceiptSubLotCommand : IRequest<bool>
    {
        public string ReceiptSublotId { get; set; }
        public double ImportedQuantity { get; set; }
        public string SubLotStatus { get; set; }
        public string UnitOfMeasure { get; set; }
        public string LocationId { get; set; }
        public string receiptLotId { get; set; }

        public CreateReceiptSubLotCommand(string receiptSublotId, double importedQuantity, string subLotStatus, string unitOfMeasure, string locationId, string receiptLotId)
        {
            ReceiptSublotId = receiptSublotId;
            ImportedQuantity = importedQuantity;
            SubLotStatus = subLotStatus;
            UnitOfMeasure = unitOfMeasure;
            LocationId = locationId;
            this.receiptLotId = receiptLotId;
        }
    }
}
