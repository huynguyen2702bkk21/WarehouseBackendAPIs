namespace WMS.Domain.AggregateModels.EquipmentAggregate
{
    public  class Equipment : Entity, IAggregateRoot
    {
        [Key]
        public string equipmentId { get; set; }

        public string equipmentName { get; set; }

        [ForeignKey("equipmentClassId")]
        public string equipmentClassId { get; set; }
        public EquipmentClass equipmentClass { get; set; }
        public List<EquipmentProperty> properties { get; set; }

        public Equipment(string equipmentId, string equipmentName, string equipmentClassId)
        {
            this.equipmentId = equipmentId;
            this.equipmentName = equipmentName;
            this.equipmentClassId = equipmentClassId;
            this.properties = new List<EquipmentProperty>();
        }

        public void AddProperty(EquipmentProperty property)
        {
            properties.Add(property);
        }

        public void UpdateEquipment(string equipmentName, string equipmentClassId)
        {
            this.equipmentName = equipmentName;
            this.equipmentClassId = equipmentClassId;
        }


    }
}
