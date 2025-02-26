namespace WMS.Application.Commands.PartyCommands.Customers
{
    public class DeleteCustomerCommand : IRequest<bool>
    {
        public string CustomerId { get; set; }

        public DeleteCustomerCommand(string customerId)
        {
            CustomerId = customerId;
        }
    }
}
