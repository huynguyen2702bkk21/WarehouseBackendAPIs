namespace WMS.Application.DTOs.EquipmentDTOs
{
    public class EquipmentPropertyDTO 
    {
        public string PropertyId { get; set; }

        public string PropertyName { get; set; }
        public string PropertyValue { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public UnitOfMeasure UnitOfMeasure { get; set; }
        public string EquipmentId { get; set; }

        public EquipmentPropertyDTO(string propertyId, string propertyName, string propertyValue, UnitOfMeasure unitOfMeasure, string equipmentId)
        {
            PropertyId = propertyId;
            PropertyName = propertyName;
            PropertyValue = propertyValue;
            UnitOfMeasure = unitOfMeasure;
            EquipmentId = equipmentId;
        }
    }
}
