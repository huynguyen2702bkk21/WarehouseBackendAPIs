namespace WMS.Application.Queries.InventoryIssueQueries.IssueLots
{
    public class GetIssueLotByIdQuery : IRequest<IssueLotDTO>
    {
        public string IssueLotId { get; set; }

        public GetIssueLotByIdQuery(string issueLotId)
        {
            IssueLotId = issueLotId;
        }
    }
}
