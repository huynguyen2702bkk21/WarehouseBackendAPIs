namespace WMS.Domain.AggregateModels.MaterialAggregate
{
    public class MaterialClassProperty : Entity, IAggregateRoot
    {
        public string propertyId { get; set; }
        public string propertyName { get; set; }
        public string propertyValue { get; set; }
        public UnitOfMeasure unitOfMeasure { get; set; }
        public string materialClassId { get; set; }
    }
}
