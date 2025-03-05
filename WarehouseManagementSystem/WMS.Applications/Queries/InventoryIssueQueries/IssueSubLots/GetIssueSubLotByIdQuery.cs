namespace WMS.Application.Queries.InventoryIssueQueries.IssueSubLots
{
    public class GetIssueSubLotByIdQuery : IRequest<IssueSubLotDTO>
    {
        public string IssueSublotId { get; set; }

        public GetIssueSubLotByIdQuery(string issueSublotId)
        {
            IssueSublotId = issueSublotId;
        }
    }
}
