namespace WMS.Application.Commands.EquipmentCommands.EquipmentClassProperties
{
    public class DeleteEquipmentClassPropertyCommand : IRequest<bool>
    {
        public string ClassPropertyId{ get; set; }

        public DeleteEquipmentClassPropertyCommand(string classPropertyId)
        {
            ClassPropertyId = classPropertyId;
        }
    }
}
