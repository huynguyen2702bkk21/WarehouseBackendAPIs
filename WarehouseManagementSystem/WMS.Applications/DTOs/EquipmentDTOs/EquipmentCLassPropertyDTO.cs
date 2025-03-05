namespace WMS.Application.DTOs.EquipmentDTOs
{
    public class EquipmentCLassPropertyDTO 
    {
        public string PropertyId { get; set; }
        public string PropertyName { get; set; }
        public string PropertyValue { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public UnitOfMeasure UnitOfMeasure { get; set; }
        public string EquipmentClassId { get; set; }

        public EquipmentCLassPropertyDTO(string propertyId, string propertyName, string propertyValue, UnitOfMeasure unitOfMeasure, string equipmentClassId)
        {
            PropertyId = propertyId;
            PropertyName = propertyName;
            PropertyValue = propertyValue;
            UnitOfMeasure = unitOfMeasure;
            EquipmentClassId = equipmentClassId;
        }
    }
}
