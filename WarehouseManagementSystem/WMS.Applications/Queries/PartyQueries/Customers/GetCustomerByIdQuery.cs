namespace WMS.Application.Queries.PartyQueries.Customers
{
    public class GetCustomerByIdQuery : IRequest<CustomerDTO>
    {
        public string CustomerId { get; set; }

        public GetCustomerByIdQuery(string customerId)
        {
            CustomerId = customerId;
        }
    }
}
