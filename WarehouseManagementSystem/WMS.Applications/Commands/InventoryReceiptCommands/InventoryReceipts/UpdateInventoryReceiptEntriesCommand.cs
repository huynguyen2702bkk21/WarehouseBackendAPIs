namespace WMS.Application.Commands.InventoryReceiptCommands.InventoryReceipts
{
    public class UpdateInventoryReceiptEntriesCommand : IRequest<bool>
    {
        public string InventoryReceiptId { get; set; }
        public List<CreateInventoryReceiptEntryCommand> Entries { get; set; }

        public UpdateInventoryReceiptEntriesCommand(string inventoryReceiptId, List<CreateInventoryReceiptEntryCommand> entries)
        {
            InventoryReceiptId = inventoryReceiptId;
            Entries = entries;
        }
    }
}
