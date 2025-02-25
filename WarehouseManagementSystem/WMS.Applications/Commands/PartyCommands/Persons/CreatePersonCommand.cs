namespace WMS.Application.Commands.PartyCommands.Persons
{
    public class CreatePersonCommand : IRequest<bool>
    {
        public string PersonId { get; set; }
        public string PersonName{ get; set; }
        public EmployeeType Role{ get; set; }

        public CreatePersonCommand(string personId, string personName, EmployeeType role)
        {
            PersonId = personId;
            PersonName = personName;
            Role = role;
        }
    }
}
