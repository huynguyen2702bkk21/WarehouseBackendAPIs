namespace WMS.Domain.AggregateModels.InventoryReceiptAggregate
{
    public class InventoryReceiptEntry : Entity, IAggregateRoot
    {
        [Key]
        public string inventoryReceiptEntryId { get; set; }
        
        public string purchaseOrderNumber { get; set; }

        [ForeignKey("materialId")]
        public string materialId { get; set; }
        public Material material { get; set; }

        public string note { get; set; }

        [ForeignKey("lotNumber")]
        public string lotNumber { get; set; }
        public ReceiptLot receiptLot { get; set; }

        public string InventoryReceiptId { get; set; }
        public InventoryReceipt inventoryReceipt { get; set; }

        public InventoryReceiptEntry()
        {
        }

        public InventoryReceiptEntry(string inventoryReceiptEntryId, string purchaseOrderNumber, string materialId, Material material, string note, string lotNumber, ReceiptLot receiptLot, string inventoryReceiptId, InventoryReceipt inventoryReceipt)
        {
            this.inventoryReceiptEntryId = inventoryReceiptEntryId;
            this.purchaseOrderNumber = purchaseOrderNumber;
            this.materialId = materialId;
            this.material = material;
            this.note = note;
            this.lotNumber = lotNumber;
            this.receiptLot = receiptLot;
            InventoryReceiptId = inventoryReceiptId;
            this.inventoryReceipt = inventoryReceipt;
        }
    }
}
