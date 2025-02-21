namespace WMS.Domain.AggregateModels.StorageAggregate
{
    public class Location : Entity, IAggregateRoot
    {
        public string locationId { get; set; }
        public List<MaterialSubLot> materialSubLots { get; set; }
    }
}
