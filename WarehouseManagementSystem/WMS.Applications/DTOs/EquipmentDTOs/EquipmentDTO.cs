namespace WMS.Application.DTOs.EquipmentDTOs
{
    public  class EquipmentDTO
    {
        public string EquipmentId { get; set; }
        public string EquipmentName { get; set; }
        public string EquipmentClassId { get; set; }
        public List<EquipmentPropertyDTO> Properties { get; set; }

        public EquipmentDTO(string equipmentId, string equipmentName, string equipmentClassId, List<EquipmentPropertyDTO> properties)
        {
            EquipmentId = equipmentId;
            EquipmentName = equipmentName;
            EquipmentClassId = equipmentClassId;
            Properties = properties;
        }
    }
}
