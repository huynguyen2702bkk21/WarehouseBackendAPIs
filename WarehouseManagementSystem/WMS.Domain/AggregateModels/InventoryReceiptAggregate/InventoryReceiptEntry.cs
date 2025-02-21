namespace WMS.Domain.AggregateModels.InventoryReceiptAggregate
{
    public class InventoryReceiptEntry : Entity, IAggregateRoot
    {
        public string inventoryReceiptEntryId { get; set; }
        public string purchaseOrderNumber { get; set; }
        public string note { get; set; }
        public string lotNumber { get; set; }

        public ReceiptLot receiptLot { get; set; }
        public string InventoryReceiptId { get; set; }

    }
}
