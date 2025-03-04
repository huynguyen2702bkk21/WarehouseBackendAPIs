namespace WMS.Application.Queries.MaterialQueries.MaterialSublots
{
    public class GetMaterialSubLotsByLocationIdQuery : IRequest<IEnumerable<MaterialSubLotDTO>>
    {
        public string LocationId { get; set; }

        public GetMaterialSubLotsByLocationIdQuery(string locationId)
        {
            LocationId = locationId;
        }
    }
}
