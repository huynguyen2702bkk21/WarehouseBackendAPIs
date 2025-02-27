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
        public List<InventoryLog> inventoryLogs { get; set; }
        public List<MaterialLotAdjustment> materialLotAdjustments { get; set; }

        public Warehouse(string warehouseId, string warehouseName)
        {
            this.warehouseId = warehouseId;
            this.warehouseName = warehouseName;
        }

        public void UpdateWarehouse(string warehouseName)
        {
            this.warehouseName = warehouseName;
        }


    }
}
