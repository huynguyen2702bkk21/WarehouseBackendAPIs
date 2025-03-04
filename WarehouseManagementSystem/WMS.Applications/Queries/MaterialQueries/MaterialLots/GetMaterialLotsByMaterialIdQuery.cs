namespace WMS.Application.Queries.MaterialQueries.MaterialLots
{
    public class GetMaterialLotsByMaterialIdQuery : IRequest<IEnumerable<MaterialLotDTO>>
    {
        public string MaterialId { get; set; }

        public GetMaterialLotsByMaterialIdQuery(string materialId)
        {
            MaterialId = materialId;
        }
    }
}
