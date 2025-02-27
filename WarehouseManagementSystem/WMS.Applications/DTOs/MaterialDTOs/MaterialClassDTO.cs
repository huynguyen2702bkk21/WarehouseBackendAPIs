namespace WMS.Application.DTOs.MaterialDTOs
{
    public class MaterialClassDTO 
    {
        public string MaterialClassId { get; set; }
        public string ClassName { get; set; }
        public List<MaterialClassPropertyDTO> Properties { get; set; }

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
    }
}
