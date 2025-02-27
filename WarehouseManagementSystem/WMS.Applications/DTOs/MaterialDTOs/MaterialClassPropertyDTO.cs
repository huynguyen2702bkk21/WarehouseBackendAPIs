namespace WMS.Application.DTOs.MaterialDTOs
{
    public class MaterialClassPropertyDTO
    {
        public string PropertyId { get; set; }

        public string PropertyName { get; set; }
        public string PropertyValue { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set; }

        public MaterialClassPropertyDTO(string propertyId, string propertyName, string propertyValue, UnitOfMeasure unitOfMeasure)
        {
            PropertyId = propertyId;
            PropertyName = propertyName;
            PropertyValue = propertyValue;
            UnitOfMeasure = unitOfMeasure;
        }
    }
}
