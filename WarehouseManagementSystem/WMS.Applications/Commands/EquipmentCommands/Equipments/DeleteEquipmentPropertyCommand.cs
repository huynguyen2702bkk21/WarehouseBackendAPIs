namespace WMS.Application.Commands.EquipmentCommands.Equipments
{
    public class DeleteEquipmentPropertyCommand : IRequest<bool>
    {
        public string EquipmentPropertyId { get; set; }

        public DeleteEquipmentPropertyCommand(string equipmentPropertyId)
        {
            EquipmentPropertyId = equipmentPropertyId;
        }
    }
}
