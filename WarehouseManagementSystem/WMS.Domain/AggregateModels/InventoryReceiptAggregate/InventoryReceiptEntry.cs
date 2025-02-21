namespace WMS.Domain.AggregateModels.InventoryReceiptAggregate
{
    public class InventoryReceiptEntry : Entity, IAggregateRoot
    {
        [Key]
        public string inventoryReceiptEntryId { get; set; }
        
        public string purchaseOrderNumber { get; set; }
        public string note { get; set; }

        [ForeignKey("lotNumber")]
        public string lotNumber { get; set; }
        public ReceiptLot receiptLot { get; set; }

        public string InventoryReceiptId { get; set; }
        public InventoryReceipt inventoryReceipt { get; set; }  
    }
}
