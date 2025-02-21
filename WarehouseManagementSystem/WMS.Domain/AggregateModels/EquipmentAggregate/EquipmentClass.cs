namespace WMS.Domain.AggregateModels.EquipmentAggregate
{
    public class EquipmentClass : Entity, IAggregateRoot
    {
        [Key]
        public string equipmentClassId { get; set; }

        public string className { get; set; }
        public List<EquipmentClassProperty> properties { get; set; }
        public List<Equipment> equipments { get; set; }
    }

}
