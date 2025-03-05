namespace WMS.Application.DTOs.EquipmentDTOs
{
    public class EquipmentCLassDTO
    {
        public string EquipmentClassId { get; set; }
        public string ClassName { get; set; }
        public List<EquipmentCLassPropertyDTO> Properties { get; set; }
        public List<EquipmentDTO> Equipments { get; set; }

        public EquipmentCLassDTO()
        {
        }

        public EquipmentCLassDTO(string equipmentClassId, string className, List<EquipmentCLassPropertyDTO> properties, List<EquipmentDTO> equipments)
        {
            EquipmentClassId = equipmentClassId;
            ClassName = className;
            Properties = properties;
            Equipments = equipments;
        }
    }
}
