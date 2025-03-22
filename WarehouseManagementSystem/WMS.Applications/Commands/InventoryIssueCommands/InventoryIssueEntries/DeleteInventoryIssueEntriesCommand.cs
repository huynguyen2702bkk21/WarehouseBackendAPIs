namespace WMS.Application.Commands.InventoryIssueCommands.InventoryIssueEntries
{
    public class DeleteInventoryIssueEntriesCommand : IRequest<bool>
    {
        public List<string> EntryIds { get; set; }

        public DeleteInventoryIssueEntriesCommand(List<string> entryIds)
        {
            EntryIds = entryIds;
        }
    }
}
