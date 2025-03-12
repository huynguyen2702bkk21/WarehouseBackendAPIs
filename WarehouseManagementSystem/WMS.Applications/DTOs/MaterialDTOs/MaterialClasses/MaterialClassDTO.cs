namespace WMS.Application.DTOs.MaterialDTOs
{
    public class MaterialClassDTO 
    {
        public string MaterialClassId { get; set; }
        public string ClassName { get; set; }
        public List<MaterialClassPropertyDTO> Properties { get; set; }
        public List<MaterialDTO> Materials { get; set; }

        public MaterialClassDTO()
        {
        }

        public MaterialClassDTO(string materialClassId, string className, List<MaterialClassPropertyDTO> properties, List<MaterialDTO> materials)
        {
            MaterialClassId = materialClassId;
            ClassName = className;
            Properties = properties;
            Materials = materials;
        }
    }
}
