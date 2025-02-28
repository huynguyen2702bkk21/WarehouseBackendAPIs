namespace WMS.Application.DTOs.MaterialDTOs
{
    public class MaterialDTO
    {
        public string MaterialId { get; set; }
        public string MaterialName { get; set; }

        public MaterialDTO(string materialId, string materialName)
        {
            MaterialId = materialId;
            MaterialName = materialName;
        }
    }
}
