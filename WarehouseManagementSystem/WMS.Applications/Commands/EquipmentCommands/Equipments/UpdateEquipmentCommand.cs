using WMS.Application.Commands.EquipmentCommands.EquipmentProperties;

namespace WMS.Application.Commands.EquipmentCommands.Equipments
{
    public class UpdateEquipmentCommand : IRequest<bool>
    {
        public string EquipmentId { get; set; }
        public string EquipmentName { get; set; }
        public string EquipmentClassId { get; set; }
        public List<UpdateEquipmentPropertyCommand> Properties { get; set; }

        public UpdateEquipmentCommand(string equipmentId, string equipmentName, string equipmentClassId, List<UpdateEquipmentPropertyCommand> properties)
        {
            EquipmentId = equipmentId;
            EquipmentName = equipmentName;
            EquipmentClassId = equipmentClassId;
            Properties = properties;
        }
    }
}
