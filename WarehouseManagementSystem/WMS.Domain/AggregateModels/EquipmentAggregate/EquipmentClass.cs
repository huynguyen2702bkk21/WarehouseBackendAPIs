namespace WMS.Domain.AggregateModels.EquipmentAggregate
{
    public class EquipmentClass : Entity, IAggregateRoot
    {
        public string equipmentClassId { get; set; }
        public string className { get; set; }
        public List<EquipmentClassProperty> properties { get; set; }
    }

}
