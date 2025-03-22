namespace WMS.Application.Commands.InventoryIssueCommands.InventoryIssues
{
    public class RefreshInventoryIssueStatusCommand : IRequest<bool>
    {
        public string InventoryIssueId { get; set; }

        public RefreshInventoryIssueStatusCommand(string inventoryIssueId)
        {
            InventoryIssueId = inventoryIssueId;
        }
    }
}
