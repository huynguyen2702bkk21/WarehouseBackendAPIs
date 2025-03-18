using WMS.Application.Commands.InventoryReceiptCommands.InventoryReceiptEntries;

namespace WMS.Application.Commands.InventoryReceiptCommands.InventoryReceipts
{
    public class CreateInventoryReceiptCommand : IRequest<bool>
    {
        public string InventoryReceiptId { get; set; }
        public DateTime ReceiptDate { get; set; }
        public string ReceiptStatus { get; set; }
        public string SupplierId { get; set; }
        public string PersonId { get; set; }
        public string WarehouseId { get; set; }
        public List<CreateInventoryReceiptEntryCommand> Entries { get; set; }

        public CreateInventoryReceiptCommand(string inventoryReceiptId, DateTime receiptDate, string receiptStatus, string supplierId, string personId, string warehouseId, List<CreateInventoryReceiptEntryCommand> entries)
        {
            InventoryReceiptId = inventoryReceiptId;
            ReceiptDate = receiptDate;
            ReceiptStatus = receiptStatus;
            SupplierId = supplierId;
            PersonId = personId;
            WarehouseId = warehouseId;
            Entries = entries;
        }
    }
}
