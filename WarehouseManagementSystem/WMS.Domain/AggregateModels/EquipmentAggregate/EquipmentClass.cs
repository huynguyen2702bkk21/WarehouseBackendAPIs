namespace WMS.Domain.AggregateModels.EquipmentAggregate
{
    public class EquipmentClass : Entity, IAggregateRoot
    {
        [Key]
        public string equipmentClassId { get; set; }

        public string className { get; set; }
        public List<EquipmentClassProperty> properties { get; set; }
        public List<Equipment> equipments { get; set; }

        public EquipmentClass(string equipmentClassId, string className)
        {
            this.equipmentClassId = equipmentClassId;
            this.className = className;
            properties = new List<EquipmentClassProperty>();
        }

        public void AddProperty(EquipmentClassProperty Properties)
        {
            properties.Add(Properties);
        }

        public void UpdateClassName(string ClassName)
        {
           className = ClassName;   
        }

    }

}
