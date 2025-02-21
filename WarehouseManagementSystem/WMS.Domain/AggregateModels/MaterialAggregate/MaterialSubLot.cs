namespace WMS.Domain.AggregateModels.MaterialAggregate
{
    public class MaterialSubLot : Entity, IAggregateRoot
    {
        public string subLotId { get; set; }
        public LotStatus subLotStatus { get; set; }
        public string locationId { get; set; }
        public Location  location{ get; set; }
        public double existingQuality { get; set; }
        public UnitOfMeasure unitOfMeasure { get; set; }
        public string lotNumber { get; set; }
    }
}
