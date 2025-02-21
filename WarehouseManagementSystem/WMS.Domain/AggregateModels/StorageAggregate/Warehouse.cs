namespace WMS.Domain.AggregateModels.StorageAggregate
{
    public class Warehouse : Entity, IAggregateRoot
    {
        [Key]
        public string warehouseId { get; set; }

        public string warehouseName { get; set; }

        public List<Location> locations { get; set; }
        public List<InventoryReceipt> inventoryReceipts { get; set; }
        public List<InventoryIssue> inventoryIssues { get; set; }
    }
}
