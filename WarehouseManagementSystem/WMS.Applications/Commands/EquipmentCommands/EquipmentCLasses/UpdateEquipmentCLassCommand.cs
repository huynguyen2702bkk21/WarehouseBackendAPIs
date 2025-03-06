namespace WMS.Application.Commands.EquipmentCommands.EquipmentCLasses
{
    public class UpdateEquipmentCLassCommand : IRequest<bool>
    {
        public string EquipmentClassId { get; set; }
        public string ClassName { get; set; }
        public List<UpdateEquipmentClassPropertyCommand> Properties { get; set; }

        public UpdateEquipmentCLassCommand(string equipmentClassId, string className, List<UpdateEquipmentClassPropertyCommand> properties)
        {
            EquipmentClassId = equipmentClassId;
            ClassName = className;
            Properties = properties;
        }
    }
}
