namespace WMS.Application.DTOs.PartyDTOs
{
    public class PersonDTO
    {
        public string PersonId { get; set; }
        public string PersonName { get; set; }
        public string EmployeeType { get; set; }

        public PersonDTO()
        {

        }

        public PersonDTO(string personId, string personName, string employeeType)
        {
            PersonId = personId;
            PersonName = personName;
            EmployeeType = employeeType;
        }
    }
}
