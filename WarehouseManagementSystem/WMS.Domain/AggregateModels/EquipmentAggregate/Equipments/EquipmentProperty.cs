namespace WMS.Domain.AggregateModels.EquipmentAggregate
{
    public class EquipmentProperty : Entity, IAggregateRoot
    {
        [Key]
        public string propertyId { get; set; }
        
        public string propertyName { get; set; }
        public string propertyValue { get; set; }
        public UnitOfMeasure unitOfMeasure { get; set; }

        [ForeignKey("equipmentId")]
        public string equipmentId { get; set; }
        public Equipment equipment { get; set; }

        public EquipmentProperty(string propertyId, string propertyName, string propertyValue, UnitOfMeasure unitOfMeasure, string equipmentId)
        {
            this.propertyId = propertyId;
            this.propertyName = propertyName;
            this.propertyValue = propertyValue;
            this.unitOfMeasure = unitOfMeasure;
            this.equipmentId = equipmentId;
        }

        public void UpdateEquipmentProperty(string propertyName, string propertyValue, UnitOfMeasure unitOfMeasure)
        {
            this.propertyName = propertyName;
            this.propertyValue = propertyValue;
            this.unitOfMeasure = unitOfMeasure;
        }

    }
}
