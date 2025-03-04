namespace WMS.Application.Commands.MaterialCommands.MaterialLots
{
    public class CreateMaterialLotPropertyCommand : IRequest<bool>
    {
        public string PropertyId { get; set; }
        public string PropertyName { get; set; }
        public string PropertyValue { get; set; }
        public string UnitOfMeasure { get; set; }
        public string MaterialLotId { get; set; }

        public CreateMaterialLotPropertyCommand(string propertyId, string propertyName, string propertyValue, string unitOfMeasure, string materialLotId)
        {
            PropertyId = propertyId;
            PropertyName = propertyName;
            PropertyValue = propertyValue;
            UnitOfMeasure = unitOfMeasure;
            MaterialLotId = materialLotId;
        }
    }
    
}
