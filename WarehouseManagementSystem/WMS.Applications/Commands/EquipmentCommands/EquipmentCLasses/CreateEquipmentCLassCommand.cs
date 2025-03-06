namespace WMS.Application.Commands.EquipmentCommands.EquipmentCLasses
{
    public class CreateEquipmentCLassCommand : IRequest<bool>
    {
        public string EquipmentClassId { get; set; }
        public string ClassName { get; set; }
        public List<CreateEquipmentClassPropertyCommand> Properties { get; set; }

        public CreateEquipmentCLassCommand(string equipmentClassId, string className, List<CreateEquipmentClassPropertyCommand> properties)
        {
            EquipmentClassId = equipmentClassId;
            ClassName = className;
            Properties = properties;
        }
    }
}
