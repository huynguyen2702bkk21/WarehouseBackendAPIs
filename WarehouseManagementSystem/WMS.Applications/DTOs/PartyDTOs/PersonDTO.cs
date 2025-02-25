namespace WMS.Application.DTOs.PartyDTOs
{
    public class PersonDTO
    {
        public string PersonId { get; set; }
        public string PersonName { get; set; }
        public EmployeeType EmployeeType { get; set; }

        public PersonDTO()
        {

        }

        public PersonDTO(string personId, string personName, EmployeeType employeeType)
        {
            PersonId = personId;
            PersonName = personName;
            EmployeeType = employeeType;
        }
    }
}
