namespace WMS.Application.Commands.EquipmentCommands.Equipments
{
    public class UpdateEquipmentPropertyCommand: IRequest<bool>
    {
        public string PropertyId { get; set; }
        public string PropertyName { get; set; }
        public string PropertyType { get; set; }
        public string PropertyValue { get; set; }
        public string EquipmentClassId { get; set; }

        public UpdateEquipmentPropertyCommand(string propertyId, string propertyName, string propertyType, string propertyValue, string equipmentClassId)
        {
            PropertyId = propertyId;
            PropertyName = propertyName;
            PropertyType = propertyType;
            PropertyValue = propertyValue;
            EquipmentClassId = equipmentClassId;
        }
    }
}
