namespace WMS.Domain.AggregateModels.InventoryReceiptAggregate
{
    public class ReceiptLot : Entity, IAggregateRoot
    {
        [Key]
        public string receiptLotId { get; set; }
        
        public double importedQuantity { get; set; }
        public List<ReceiptSublot> receiptSublots { get; set; }
        public LotStatus lotStatus { get; set; }

        [ForeignKey("inventoryReceiptEntryId")]
        public string InventoryReceiptEntryId { get; set; }
        public InventoryReceiptEntry inventoryReceiptEntry { get; set; }

    }
}
