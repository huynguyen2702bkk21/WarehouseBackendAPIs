namespace WMS.Application.Commands.InventoryReceiptCommands.InventoryReceiptEntries
{
    public class DeleteInventoryReceiptEntriesCommand : IRequest<bool>
    {
        public List<string> entryIds { get; set; }

        public DeleteInventoryReceiptEntriesCommand(List<string> entryIds)
        {
            this.entryIds = entryIds;
        }
    }
}
