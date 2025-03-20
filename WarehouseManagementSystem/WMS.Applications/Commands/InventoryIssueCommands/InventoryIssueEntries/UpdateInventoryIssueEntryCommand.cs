namespace WMS.Application.Commands.InventoryIssueCommands.InventoryIssueEntries
{
    public class UpdateInventoryIssueEntryCommand : IRequest<bool>
    {
        public string InventoryIssueId { get; set; }
        public List<CreateInventoryIssueEntryCommand> Entries { get; set; }

        public UpdateInventoryIssueEntryCommand(string inventoryIssueId, List<CreateInventoryIssueEntryCommand> entries)
        {
            InventoryIssueId = inventoryIssueId;
            Entries = entries;
        }
    }
}
