namespace WMS.Application.Queries.MaterialQueries.MaterialSublots
{
    public class GetMaterialSubLotsByStatusQuery : IRequest<IEnumerable<MaterialSubLotDTO>>
    {
        public string Status { get; set; }

        public GetMaterialSubLotsByStatusQuery(string status)
        {
            Status = status;
        }
    }
}
