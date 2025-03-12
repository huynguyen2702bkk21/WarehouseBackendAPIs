using System.ComponentModel.DataAnnotations.Schema;

namespace WMS.Application.DTOs.MaterialDTOs
{
    public class MaterialPropertyDTO
    {
        public string PropertyId { get; set; }
        public string PropertyName { get; set; }
        public string PropertyValue { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public UnitOfMeasure UnitOfMeasure { get; set; }
        public string MaterialId { get; set; }

        public MaterialPropertyDTO(string propertyId, string propertyName, string propertyValue, UnitOfMeasure unitOfMeasure, string materialId)
        {
            PropertyId = propertyId;
            PropertyName = propertyName;
            PropertyValue = propertyValue;
            UnitOfMeasure = unitOfMeasure;
            MaterialId = materialId;
        }
    }
}
