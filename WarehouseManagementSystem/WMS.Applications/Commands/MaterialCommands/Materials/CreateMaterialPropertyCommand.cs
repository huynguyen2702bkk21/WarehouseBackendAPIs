namespace WMS.Application.Commands.MaterialCommands.Materials
{
    public class CreateMaterialPropertyCommand : IRequest<bool>
    {
        public string PropertyId { get; set; }
        public string PropertyName { get; set; }
        public string PropertyValue { get; set; }
        public string UnitOfMeasure { get; set; }
        public string MaterialId { get; set; }

        public CreateMaterialPropertyCommand(string propertyId, string propertyName, string propertyValue, string unitOfMeasure, string materialId)
        {
            PropertyId = propertyId;
            PropertyName = propertyName;
            PropertyValue = propertyValue;
            UnitOfMeasure = unitOfMeasure;
            MaterialId = materialId;
        }
    }
}
