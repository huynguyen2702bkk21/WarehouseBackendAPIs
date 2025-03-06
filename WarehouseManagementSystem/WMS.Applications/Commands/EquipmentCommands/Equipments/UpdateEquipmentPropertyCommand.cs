namespace WMS.Application.Commands.EquipmentCommands.Equipments
{
    public class UpdateEquipmentPropertyCommand: IRequest<bool>
    {
        public string PropertyId { get; set; }
        public string PropertyName { get; set; }
        public string PropertyValue { get; set; }
        public string UnitOfMeasure { get; set; }
        public string EquipmentId { get; set; }

        public UpdateEquipmentPropertyCommand(string propertyId, string propertyName, string propertyValue, string unitOfMeasure, string equipmentId)
        {
            PropertyId = propertyId;
            PropertyName = propertyName;
            PropertyValue = propertyValue;
            UnitOfMeasure = unitOfMeasure;
            EquipmentId = equipmentId;
        }
    }
}
