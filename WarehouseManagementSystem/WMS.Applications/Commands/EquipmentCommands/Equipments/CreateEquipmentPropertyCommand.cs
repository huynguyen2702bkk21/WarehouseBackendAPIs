namespace WMS.Application.Commands.EquipmentCommands.EquipmentProperties
{
    public class CreateEquipmentPropertyCommand : IRequest<bool>
    {
        public string PropertyId { get; set; }
        public string PropertyName { get; set; }
        public string PropertyType { get; set; }
        public string PropertyValue { get; set; }
        public string EquipmentClassId { get; set; }
        public CreateEquipmentPropertyCommand(string equipmentPropertyId, string equipmentClassId, string propertyName, string propertyType, string propertyValue)
        {
            PropertyId = equipmentPropertyId;
            EquipmentClassId = equipmentClassId;
            PropertyName = propertyName;
            PropertyType = propertyType;
            PropertyValue = propertyValue;
        }
    }
}
