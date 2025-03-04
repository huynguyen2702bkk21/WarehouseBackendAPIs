namespace WMS.Application.DTOs.MaterialDTOs
{
    public class MaterialClassDTO 
    {
        public string MaterialClassId { get; set; }
        public string ClassName { get; set; }
        public List<MaterialClassPropertyDTO> Properties { get; set; }
        public List<MaterialDTO> MaterialDTOs { get; set; }

        public MaterialClassDTO()
        {
        }

        public MaterialClassDTO(string materialClassId, string className, List<MaterialClassPropertyDTO> properties)
        {
            MaterialClassId = materialClassId;
            ClassName = className;
            Properties = properties;    
        }

        public MaterialClassDTO(string materialClassId, string className)
        {
            MaterialClassId = materialClassId;
            ClassName = className;
        }

        public MaterialClassDTO(string materialClassId, string className, List<MaterialClassPropertyDTO> properties, List<MaterialDTO> materialDTOs) : this(materialClassId, className, properties)
        {
            MaterialDTOs = materialDTOs;
        }
    }
}
