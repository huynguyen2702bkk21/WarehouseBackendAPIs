namespace WMS.Application.DTOs.MaterialDTOs
{
    public class MaterialClassPropertyDTO
    {
        public string PropertyId { get; set; }

        public string PropertyName { get; set; }
        public string PropertyValue { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public UnitOfMeasure UnitOfMeasure { get; set; }
        public string MaterialClassId { get; set; }

        public MaterialClassPropertyDTO(string propertyId, string propertyName, string propertyValue, UnitOfMeasure unitOfMeasure, string materialClassId)
        {
            PropertyId = propertyId;
            PropertyName = propertyName;
            PropertyValue = propertyValue;
            UnitOfMeasure = unitOfMeasure;
            MaterialClassId = materialClassId;
        }
    }
}
