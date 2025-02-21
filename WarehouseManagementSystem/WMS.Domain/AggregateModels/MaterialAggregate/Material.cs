namespace WMS.Domain.AggregateModels.MaterialAggregate
{
    public class Material : Entity, IAggregateRoot
    {
        public string materialId { get; set; }
        public string materialName { get; set; }
        public string materialClassId { get; set; }
        public MaterialClass materialClass { get; set; }
        public List<MaterialProperty> porperties { get; set; }

    }
}
