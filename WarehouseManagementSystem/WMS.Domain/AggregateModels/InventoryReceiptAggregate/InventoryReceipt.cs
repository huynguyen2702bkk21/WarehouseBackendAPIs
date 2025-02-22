namespace WMS.Domain.AggregateModels.InventoryReceiptAggregate
{
    public class InventoryReceipt : Entity, IAggregateRoot
    {
        [Key]
        public string inventoryReceiptId { get; set; }
        
        public DateTime receiptDate { get; set; }
        public ReceiptStatus receiptStatus { get; set; }

        [ForeignKey("supplierId")]
        public string supplierId { get; set; }
        public Supplier supplier { get; set; }

        [ForeignKey("personId")]
        public string personId { get; set; }
        public Person receivedBy { get; set; }

        [ForeignKey("warehouseId")]
        public string warehouseId { get; set; }
        public Warehouse warehouse { get; set; }

        public List<InventoryReceiptEntry> entries { get; set; }
    }
}
