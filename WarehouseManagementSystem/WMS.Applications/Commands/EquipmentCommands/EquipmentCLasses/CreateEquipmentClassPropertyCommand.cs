namespace WMS.Application.Commands.EquipmentCommands.EquipmentCLasses
{
    public class CreateEquipmentClassPropertyCommand : IRequest<bool>
    {
        public string PropertyId { get; set; }
        public string PropertyName { get; set; }
        public string PropertyValue { get; set; }
        public string UnitOfMeasure { get; set; }
        public string EquipmentClassId { get; set; }

        public CreateEquipmentClassPropertyCommand(string propertyId, string propertyName, string propertyValue, string unitOfMeasure, string equipmentClassId)
        {
            PropertyId = propertyId;
            PropertyName = propertyName;
            PropertyValue = propertyValue;
            UnitOfMeasure = unitOfMeasure;
            EquipmentClassId = equipmentClassId;
        }
    }
}
