namespace WMS.Domain.AggregateModels.MaterialAggregate
{
    public class MaterialClass : Entity, IAggregateRoot
    {
        public string materialClassId { get; set; }
        public string className { get; set; }
        public List<MaterialClassProperty> properties { get; set; }
    }
}