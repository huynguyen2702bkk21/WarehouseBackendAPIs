namespace WMS.Domain.AggregateModels.InventoryReceiptAggregate
{
    public class InventoryReceipt : Entity, IAggregateRoot
    {
        public string inventoryReceiptId { get; set; }
        public DateTime receiptDate { get; set; }
        public ReceiptStatus receiptStatus { get; set; }

        public string supplierId { get; set; }
        public Supplier supplier { get; set; }

        public string employeeId { get; set; }
        public Employee receivedBy { get; set; }

        public string warehouseId { get; set; }
        public Warehouse warehouse { get; set; }

        public List<InventoryReceiptEntry> entries { get; set; }
    }
}
