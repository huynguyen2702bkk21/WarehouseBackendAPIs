namespace WMS.Application.Queries.InventoryIssueQueries.InventoryIssues
{
    public class GetInventoryIssueEntryByIdQuery : IRequest<InventoryIssueEntryDTO>
    {
        public string InventoryIssueEntryId { get; set; }

        public GetInventoryIssueEntryByIdQuery(string inventoryIssueEntryId)
        {
            InventoryIssueEntryId = inventoryIssueEntryId;
        }
    }
}
