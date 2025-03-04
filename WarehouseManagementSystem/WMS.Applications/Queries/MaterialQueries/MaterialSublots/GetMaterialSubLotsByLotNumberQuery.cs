namespace WMS.Application.Queries.MaterialQueries.MaterialSublots
{
    public class GetMaterialSubLotsByLotNumberQuery : IRequest<IEnumerable<MaterialSubLotDTO>>
    {
        public string LotNumber { get; set; }

        public GetMaterialSubLotsByLotNumberQuery(string lotNumber)
        {
            LotNumber = lotNumber;
        }
    }
}