namespace WMS.Application.Commands.InventoryReceiptCommands.InventoryReceipts
{
    public class UpdateInventoryReceiptCommand : IRequest<bool>
    {
        public string InventoryReceiptId { get; set; }
        public string SupplierId { get; set; }
        public string PersonId { get; set; }
        public string WarehouseId { get; set; }

        public UpdateInventoryReceiptCommand(string inventoryReceiptId, string supplierId, string personId, string warehouseId)
        {
            InventoryReceiptId = inventoryReceiptId;
            SupplierId = supplierId;
            PersonId = personId;
            WarehouseId = warehouseId;
        }
    }
}
