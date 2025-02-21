namespace WMS.Domain.AggregateModels.EquipmentAggregate
{
    public  class Equipment : Entity, IAggregateRoot
    {
        public string equipmentId { get; set; }
        public string equipmentName { get; set; }
        public string equipmentClassId { get; set; }
        public EquipmentClass equipmentClass { get; set; }
        public List<EquipmentProperty> properties { get; set; }
    }
}
