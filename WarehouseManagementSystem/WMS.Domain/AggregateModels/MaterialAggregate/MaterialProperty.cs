namespace WMS.Domain.AggregateModels.MaterialAggregate
{
    public class MaterialProperty
    {
        [Key]
        public string propertyId { get; set; }

        public string propertyName { get; set; }
        public string propertyValue { get; set; }
        public UnitOfMeasure unitOfMeasure { get; set; }

        [ForeignKey("materialId")]
        public string materialId { get; set; }
        public Material material { get; set; }
    }
}
