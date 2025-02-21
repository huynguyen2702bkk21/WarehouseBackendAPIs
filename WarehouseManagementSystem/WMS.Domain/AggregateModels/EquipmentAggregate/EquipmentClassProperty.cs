namespace WMS.Domain.AggregateModels.EquipmentAggregate
{
    public class EquipmentClassProperty : Entity
    {
        [Key]
        public string propertyId { get; set; }

        public string propertyName { get; set; }
        public string propertyValue { get; set; }
        public UnitOfMeasure unitOfMeasure { get; set; }

        [ForeignKey("equipmentClassId")]
        public string equipmentClassId { get; set; }
        public EquipmentClass equipmentClass { get; set; }
    }
}
