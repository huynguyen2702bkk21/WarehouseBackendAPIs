namespace WMS.Application.Queries.MaterialQueries.MaterialLots
{
    public class GetMaterialLotPropertyByIdQuery : IRequest<MaterialLotPropertyDTO>
    {
        public string Id { get; set; }

        public GetMaterialLotPropertyByIdQuery(string id)
        {
            Id = id;
        }
    }
}
