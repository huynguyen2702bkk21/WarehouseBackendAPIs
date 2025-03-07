namespace WMS.Application.Queries.InventoryIssueQueries.InventoryIssues
{
    public class GetInventoryIssueByIdQuery : IRequest<InventoryIssueDTO>
    {
        public string InventoryIssueId { get; set; }

        public GetInventoryIssueByIdQuery(string inventoryIssueId)
        {
            InventoryIssueId = inventoryIssueId;
        }
    }
}
