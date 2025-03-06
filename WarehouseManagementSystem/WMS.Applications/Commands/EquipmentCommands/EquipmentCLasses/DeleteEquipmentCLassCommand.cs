namespace WMS.Application.Commands.EquipmentCommands.EquipmentCLasses
{
    public class DeleteEquipmentCLassCommand : IRequest<bool>
    {
        public string EquipmentClassId { get; set; }

        public DeleteEquipmentCLassCommand(string equipmentClassId)
        {
            EquipmentClassId = equipmentClassId;
        }
    }
}
