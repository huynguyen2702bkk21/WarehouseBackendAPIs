namespace WMS.Domain.AggregateModels.MaterialAggregate
{
    public class MaterialLotProperty : Entity, IAggregateRoot
    {
        [Key]
        public string propertyId { get; set; }
        
        public string propertyName { get; set; }
        public string propertyValue { get; set; }

        [ForeignKey("lotNumber")]
        public string lotNumber { get; set; }
        public MaterialLot materialLot { get; set; }

        public UnitOfMeasure unitOfMeasure { get; set; }
    }
}
