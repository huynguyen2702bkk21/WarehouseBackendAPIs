namespace WMS.Application.Queries.PartyQueries.Suppliers
{
    public class GetSupplierByIdQuery : IRequest<SupplierDTO>
    {
        public string Id { get; set; }

        public GetSupplierByIdQuery(string id)
        {
            Id = id;
        }
    }
}
