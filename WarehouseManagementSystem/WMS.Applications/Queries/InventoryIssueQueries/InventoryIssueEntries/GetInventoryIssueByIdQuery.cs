namespace WMS.Application.Queries.InventoryIssueQueries.InventoryIssueEntries
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
