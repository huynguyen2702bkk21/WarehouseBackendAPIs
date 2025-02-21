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
    }
}
