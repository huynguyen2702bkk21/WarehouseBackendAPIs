namespace WMS.Application.Queries.PartyQueries.Persons
{
    public class GetPersonPropertyByIdQuery : IRequest<PersonPropertyDTO>
    {
        public string PropertyId { get; set; }

        public GetPersonPropertyByIdQuery(string propertyId)
        {
            PropertyId = propertyId;
        }
    }
}
