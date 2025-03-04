namespace WMS.Application.Queries.MaterialQueries.MaterialLots
{
    public class GetMaterialLotsByStatusQuery : IRequest<IEnumerable<MaterialLotDTO>>
    {
        public string Status { get; set; }

        public GetMaterialLotsByStatusQuery(string status)
        {
            Status = status;
        }
    }
}
