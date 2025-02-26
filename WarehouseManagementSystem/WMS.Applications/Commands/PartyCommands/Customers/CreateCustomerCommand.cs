namespace WMS.Application.Commands.PartyCommands.Customers
{
    public class CreateCustomerCommand : IRequest<bool>
    {
        public string CustomerId { get; set; }

        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string ContactDetails { get; set; }

        public CreateCustomerCommand(string customerId, string customerName, string address, string contactDetails)
        {
            CustomerId = customerId;
            CustomerName = customerName;
            Address = address;
            ContactDetails = contactDetails;
        }
    }
}
