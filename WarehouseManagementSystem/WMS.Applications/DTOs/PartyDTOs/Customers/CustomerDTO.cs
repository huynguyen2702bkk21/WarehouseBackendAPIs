namespace WMS.Application.DTOs.PartyDTOs
{
    public class CustomerDTO
    {
        public string CustomerId { get; set; }

        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string ContactDetails { get; set; }

        public CustomerDTO()
        {
        }

        public CustomerDTO(string customerId, string customerName, string address, string contactDetails)
        {
            CustomerId = customerId;
            CustomerName = customerName;
            Address = address;
            ContactDetails = contactDetails;
        }
    }
}
