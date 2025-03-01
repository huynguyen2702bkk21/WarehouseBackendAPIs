namespace WMS.Application.Commands.MaterialCommands.MaterialClasses
{
    public class UpdateMaterialClassPropertyCommand : IRequest<bool>
    {
        public string PropertyId { get; set; }
        public string PropertyName { get; set; }
        public string PropertyValue { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set; }
        public string MaterialClassId { get; set; }

        public UpdateMaterialClassPropertyCommand(string propertyId, string propertyName, string propertyValue, UnitOfMeasure unitOfMeasure, string materialClassId)
        {
            PropertyId = propertyId;
            PropertyName = propertyName;
            PropertyValue = propertyValue;
            UnitOfMeasure = unitOfMeasure;
            MaterialClassId = materialClassId;
        }
    }
}
