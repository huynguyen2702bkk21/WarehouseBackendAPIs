namespace WMS.Application.Commands.PartyCommands.Persons
{
    public class DeletePersonPropertyCommand : IRequest<bool>
    {
        public string PropertyId { get; set; }

        public DeletePersonPropertyCommand(string propertyId)
        {
            PropertyId = propertyId;
        }
    }
}
