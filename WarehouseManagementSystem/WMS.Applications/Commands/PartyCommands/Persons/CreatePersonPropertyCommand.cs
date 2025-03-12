namespace WMS.Application.Commands.PartyCommands.Persons
{
    public class CreatePersonPropertyCommand: IRequest<bool>
    {
        public string PropertyId { get; set; }
        public string PropertyName { get; set; }
        public string PropertyValue { get; set; }
        public string UnitOfMeasure { get; set; }
        public string PersonId { get; set; }

        public CreatePersonPropertyCommand(string propertyId, string propertyName, string propertyValue, string unitOfMeasure, string personId)
        {
            PropertyId = propertyId;
            PropertyName = propertyName;
            PropertyValue = propertyValue;
            UnitOfMeasure = unitOfMeasure;
            PersonId = personId;
        }
    }
}
