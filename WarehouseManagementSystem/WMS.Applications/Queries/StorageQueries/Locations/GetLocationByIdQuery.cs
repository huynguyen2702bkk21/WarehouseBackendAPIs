namespace WMS.Application.Queries.StorageQueries.Locations
{
    public class GetLocationByIdQuery : IRequest<LocationDTO>
    {
        public string Id { get; set; }

        public GetLocationByIdQuery(string id)
        {
            Id = id;
        }
    }
}
