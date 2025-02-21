namespace WMS.Domain.AggregateModels.MaterialAggregate
{
    public class MaterialSubLot : Entity, IAggregateRoot
    {
        [Key]
        public string subLotId { get; set; }
        public LotStatus subLotStatus { get; set; }
        public double existingQuality { get; set; }
        public UnitOfMeasure unitOfMeasure { get; set; }

        [ForeignKey("locationId")]
        public string locationId { get; set; }
        public Location  location{ get; set; }

        [ForeignKey("lotNumber")]
        public string lotNumber { get; set; }
        public MaterialLot materialLot { get; set; }
    }
}
