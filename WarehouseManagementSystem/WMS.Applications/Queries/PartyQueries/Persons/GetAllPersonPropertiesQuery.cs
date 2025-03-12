using WMS.Application.DTOs.PartyDTOs.People;

namespace WMS.Application.Queries.PartyQueries.Persons
{
    public class GetAllPersonPropertiesQuery : IRequest<IEnumerable<PersonPropertyDTO>>
    {
        public GetAllPersonPropertiesQuery()
        {
        }
    }
}
