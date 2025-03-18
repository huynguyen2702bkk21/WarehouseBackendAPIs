using WMS.Application.Commands.InventoryReceiptCommands.ReceiptLots;

namespace WMS.Application.Commands.InventoryReceiptCommands.InventoryReceiptEntries
{
    public class CreateInventoryReceiptEntryCommand : IRequest<bool>
    {
        public string InventoryReceiptEntryId { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string MaterialId { get; set; }
        public string Note { get; set; }
        public string InventoryReceiptId { get; set; }
        public string LotNumber { get; set; }
        public CreateReceiptLotCommand ReceiptLot { get; set; }

        public CreateInventoryReceiptEntryCommand(string inventoryReceiptEntryId, string purchaseOrderNumber, string materialId, string note, string inventoryReceiptId, string lotNumber, CreateReceiptLotCommand receiptLot)
        {
            InventoryReceiptEntryId = inventoryReceiptEntryId;
            PurchaseOrderNumber = purchaseOrderNumber;
            MaterialId = materialId;
            Note = note;
            InventoryReceiptId = inventoryReceiptId;
            LotNumber = lotNumber;
            ReceiptLot = receiptLot;
        }
    }
}
