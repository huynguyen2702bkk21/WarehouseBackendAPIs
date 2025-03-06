namespace WMS.Domain.AggregateModels.EquipmentAggregate
{
    public class EquipmentClassProperty : Entity, IAggregateRoot
    {
        [Key]
        public string propertyId { get; set; }

        public string propertyName { get; set; }
        public string propertyValue { get; set; }
        public UnitOfMeasure unitOfMeasure { get; set; }

        [ForeignKey("equipmentClassId")]
        public string equipmentClassId { get; set; }
        public EquipmentClass equipmentClass { get; set; }

        public EquipmentClassProperty(string propertyId, string propertyName, string propertyValue, UnitOfMeasure unitOfMeasure, string equipmentClassId)
        {
            this.propertyId = propertyId;
            this.propertyName = propertyName;
            this.propertyValue = propertyValue;
            this.unitOfMeasure = unitOfMeasure;
            this.equipmentClassId = equipmentClassId;
        }

        public void UpdateProperty(string PropertyName, string propertyValue, UnitOfMeasure UnitOfMeasure)
        {
            this.propertyName = PropertyName;
            this.propertyValue = propertyValue;
            this.unitOfMeasure = UnitOfMeasure;
        }

    }
}
