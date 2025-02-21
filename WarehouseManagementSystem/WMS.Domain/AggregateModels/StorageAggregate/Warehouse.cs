namespace WMS.Domain.AggregateModels.StorageAggregate
{
    public class Warehouse : Entity, IAggregateRoot
    {
        public string warehouseId { get; set; }
        public string warehouseName { get; set; }
        public List<Location> locations { get; set; }
     }
}
