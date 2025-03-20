namespace WMS.Application.Queries.InventoryTracking.InventoryLogs
{
    public class GetInventoryLogByLotNumberQuery : IRequest<IEnumerable<InventoryLogDTO>>
    {
        public string LotNumber { get; set; }

        public GetInventoryLogByLotNumberQuery(string lotNumber)
        {
            LotNumber = lotNumber;
        }
    }
}
