namespace WMS.Application.Commands.InventoryIssueCommands.InventoryIssues
{
    public class DeleteInventoryIssueCommand : IRequest<bool>
    {
        public string InventoryIssueId { get; set; }

        public DeleteInventoryIssueCommand(string inventoryIssueId)
        {
            InventoryIssueId = inventoryIssueId;
        }

    }
}
