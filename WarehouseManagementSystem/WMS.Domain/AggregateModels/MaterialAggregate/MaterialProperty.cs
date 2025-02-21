namespace WMS.Domain.AggregateModels.MaterialAggregate
{
    public class MaterialProperty
    {
        public string propertyId { get; set; }
        public string propertyName { get; set; }
        public string propertyValue { get; set; }
        public UnitOfMeasure unitOfMeasure { get; set; }
        public string materialId { get; set; }
    }
}
