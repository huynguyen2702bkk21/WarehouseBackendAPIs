namespace WMS.Application.DTOs.MaterialDTOs
{
    public class MaterialDTO
    {
        public string MaterialId { get; set; }
        public string MaterialName { get; set; }
        public string MaterialClassId { get; set; }
        public List<MaterialPropertyDTO> Properties { get; set; }

        public MaterialDTO()
        {
        }

        public MaterialDTO(string materialId, string materialName, string materialClassId, List<MaterialPropertyDTO> properties)
        {
            MaterialId = materialId;
            MaterialName = materialName;
            MaterialClassId = materialClassId;
            Properties = properties;
        }
    }
}
