namespace WMS.Application.Commands.PartyCommands.Persons
{
    public class UpdatePersonCommand : IRequest<bool>
    {
        public string PersonId { get; set; }
        public string PersonName { get; set; }
        public EmployeeType Role {  get; set; }

        public UpdatePersonCommand(string personId, string personName, EmployeeType role)
        {
            PersonId = personId;
            PersonName = personName;
            Role = role;
        }
    }
}
