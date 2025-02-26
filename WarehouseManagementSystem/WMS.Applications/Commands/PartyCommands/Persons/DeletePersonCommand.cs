namespace WMS.Application.Commands.PartyCommands.Persons
{
    public class DeletePersonCommand : IRequest<bool>
    {
        public string PersonId { get; set; }

        public DeletePersonCommand(string personId)
        {
            PersonId = personId;
        }
    }
}
