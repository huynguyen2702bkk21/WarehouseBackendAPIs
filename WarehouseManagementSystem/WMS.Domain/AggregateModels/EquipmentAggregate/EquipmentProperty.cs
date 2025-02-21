namespace WMS.Domain.AggregateModels.EquipmentAggregate
{
    public class EquipmentProperty : Entity, IAggregateRoot
    {
        public string propertyId { get; set; }
        public string propertyName { get; set; }
        public string propertyValue { get; set; }
        public UnitOfMeasure unitOfMeasure { get; set; }
        public string equipmentId { get; set; }
    }
}
