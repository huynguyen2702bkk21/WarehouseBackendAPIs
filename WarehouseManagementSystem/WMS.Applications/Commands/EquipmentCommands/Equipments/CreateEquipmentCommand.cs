using WMS.Application.Commands.EquipmentCommands.EquipmentProperties;

namespace WMS.Application.Commands.EquipmentCommands.Equipments
{
    public class CreateEquipmentCommand : IRequest<bool>
    {
        public string EquipmentId { get; set; }
        public string EquipmentName { get; set; }
        public string EquipmentClassId { get; set; }
        public List<CreateEquipmentPropertyCommand> Properties { get; set; }

        public CreateEquipmentCommand()
        {
        }

        public CreateEquipmentCommand(string equipmentId, string equipmentName, string equipmentClassId, List<CreateEquipmentPropertyCommand> properties)
        {
            EquipmentId = equipmentId;
            EquipmentName = equipmentName;
            EquipmentClassId = equipmentClassId;
            Properties = properties;
        }
    }
}
