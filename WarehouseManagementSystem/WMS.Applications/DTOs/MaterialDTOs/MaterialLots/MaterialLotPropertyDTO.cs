namespace WMS.Application.DTOs.MaterialDTOs
{
    public class MaterialLotPropertyDTO
    {
        public string PropertyId { get; set; }
        public string PropertyName { get; set; }
        public string PropertyValue { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public UnitOfMeasure UnitOfMeasure { get; set; }
        public string LotNumber { get; set; }
        public MaterialLotPropertyDTO(string propertyId, string propertyName, string propertyValue, UnitOfMeasure unitOfMeasure, string lotNumber)
        {
            PropertyId = propertyId;
            PropertyName = propertyName;
            PropertyValue = propertyValue;
            UnitOfMeasure = unitOfMeasure;
            LotNumber = lotNumber;
        }
    }
}
