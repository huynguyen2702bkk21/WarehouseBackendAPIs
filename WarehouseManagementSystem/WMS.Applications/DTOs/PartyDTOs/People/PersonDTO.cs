using WMS.Application.DTOs.PartyDTOs.People;

namespace WMS.Application.DTOs.PartyDTOs
{
    public class PersonDTO
    {
        public string PersonId { get; set; }
        public string PersonName { get; set; }
        public string EmployeeType { get; set; }
        public List<PersonPropertyDTO> personPropertyDTOs { get; set; }

        public PersonDTO()
        {

        }

        public PersonDTO(string personId, string personName, string employeeType, List<PersonPropertyDTO> personPropertyDTOs)
        {
            PersonId = personId;
            PersonName = personName;
            EmployeeType = employeeType;
            this.personPropertyDTOs = personPropertyDTOs;
        }
    }
}
