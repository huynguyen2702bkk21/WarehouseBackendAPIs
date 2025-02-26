namespace WMS.Application.Queries.PartyQueries.Persons
{
    public class GetPersonByIdQuery : IRequest<PersonDTO>
    {
        public string PersonId { get; set; }

        public GetPersonByIdQuery(string personId)
        {
            PersonId = personId;
        }
    }
}
