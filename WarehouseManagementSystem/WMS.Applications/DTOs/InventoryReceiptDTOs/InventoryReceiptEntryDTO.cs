namespace WMS.Application.DTOs.InventoryReceiptDTOs
{
    public class InventoryReceiptEntryDTO
    {
        public string InventoryReceiptEntryId { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string MaterialName { get; set; }
        public string Note { get; set; }
        public string InventoryReceiptId { get; set; }
        public string LotNumber { get; set; }
        public ReceiptLotDTO ReceiptLot { get; set; }

        public InventoryReceiptEntryDTO()
        {
        }

        public InventoryReceiptEntryDTO(string inventoryReceiptEntryId, string purchaseOrderNumber, string materialName, string note, string inventoryReceiptId, string lotNumber)
        {
            InventoryReceiptEntryId = inventoryReceiptEntryId;
            PurchaseOrderNumber = purchaseOrderNumber;
            MaterialName = materialName;
            Note = note;
            InventoryReceiptId = inventoryReceiptId;
            LotNumber = lotNumber;
        }

        public void MapName(string materialName)
        {
            MaterialName = materialName;
        }

        public void MapReceiptLot(ReceiptLotDTO receiptLot)
        {
            ReceiptLot = receiptLot;
        }

    }
}
