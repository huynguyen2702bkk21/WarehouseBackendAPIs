namespace WMS.Application.Commands.PartyCommands.Persons
{
    public class CreatePersonCommand : IRequest<bool>
    {
        public string PersonId { get; set; }
        public string PersonName{ get; set; }
        public string Role{ get; set; }

        public CreatePersonCommand(string personId, string personName, string role)
        {
            PersonId = personId;
            PersonName = personName;
            Role = role;
        }
    }
}
