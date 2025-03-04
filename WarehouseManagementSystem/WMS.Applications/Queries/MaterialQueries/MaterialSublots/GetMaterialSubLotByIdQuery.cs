namespace WMS.Application.Queries.MaterialQueries.MaterialSublots
{
    public class GetMaterialSubLotByIdQuery : IRequest<MaterialSubLotDTO>
    {
        public string Id { get; set; }

        public GetMaterialSubLotByIdQuery(string id)
        {
            Id = id;
        }
    }
}
