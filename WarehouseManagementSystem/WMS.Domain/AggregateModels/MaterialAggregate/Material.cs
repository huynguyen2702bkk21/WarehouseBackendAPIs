namespace WMS.Domain.AggregateModels.MaterialAggregate
{
    public class Material : Entity, IAggregateRoot
    {
        [Key]
        public string materialId { get; set; }
        public string materialName { get; set; }

        [ForeignKey("materialClassId")]
        public string materialClassId { get; set; }
        public MaterialClass materialClass { get; set; }

        public List<MaterialProperty> porperties { get; set; }
        public List<MaterialLot> lots { get; set; }

    }
}
