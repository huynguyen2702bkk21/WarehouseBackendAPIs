namespace WMS.Domain.AggregateModels.InventoryReceiptAggregate
{
    public class ReceiptLot : Entity, IAggregateRoot
    {
        [Key]
        public string receiptLotId { get; set; }
        
        public double importedQuantity { get; set; }
        public List<ReceiptSublot> receiptSublots { get; set; }
        public LotStatus receiptLotStatus { get; set; }

        [ForeignKey("inventoryReceiptEntryId")]
        public string InventoryReceiptEntryId { get; set; }
        public InventoryReceiptEntry inventoryReceiptEntry { get; set; }

        public ReceiptLot()
        {
        }

        public ReceiptLot(string receiptLotId, double importedQuantity, LotStatus receiptLotStatus, string inventoryReceiptEntryId)
        {
            this.receiptLotId = receiptLotId;
            this.importedQuantity = importedQuantity;
            this.receiptSublots = new List<ReceiptSublot>();
            this.receiptLotStatus = receiptLotStatus;
            InventoryReceiptEntryId = inventoryReceiptEntryId;
        }

        public ReceiptLot(string receiptLotId, double importedQuantity, List<ReceiptSublot> receiptSublots, LotStatus receiptLotStatus, string inventoryReceiptEntryId, InventoryReceiptEntry inventoryReceiptEntry)
        {
            this.receiptLotId = receiptLotId;
            this.importedQuantity = importedQuantity;
            this.receiptSublots = receiptSublots;
            this.receiptLotStatus = receiptLotStatus;
            InventoryReceiptEntryId = inventoryReceiptEntryId;
            this.inventoryReceiptEntry = inventoryReceiptEntry;
        }

        public void AddSublot(ReceiptSublot sublot)
        {
            receiptSublots.Add(sublot);
        }

        public void Update(double importedQuantity, LotStatus receiptLotStatus)
        {
            this.importedQuantity = importedQuantity;
            this.receiptLotStatus = receiptLotStatus;
        }


    }
}
