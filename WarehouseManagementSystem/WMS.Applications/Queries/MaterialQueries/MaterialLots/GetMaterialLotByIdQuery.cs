namespace WMS.Application.Queries.MaterialQueries.MaterialLots
{
    public class GetMaterialLotByIdQuery : IRequest<MaterialLotDTO>
    {
        public string LotNumber { get; set; }

        public GetMaterialLotByIdQuery(string lotNumber)
        {
            LotNumber = lotNumber;
        }
    }
}
