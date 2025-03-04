namespace WMS.Application.Commands.PartyCommands.Persons
{
    public class UpdatePersonCommand : IRequest<bool>
    {
        public string PersonId { get; set; }
        public string PersonName { get; set; }
        public string Role {  get; set; }

        public UpdatePersonCommand(string personId, string personName, string role)
        {
            PersonId = personId;
            PersonName = personName;
            Role = role;
        }
    }
}
