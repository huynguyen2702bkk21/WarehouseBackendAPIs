namespace WMS.Application.DTOs.InventoryReceiptDTOs
{
    public class ReceiptLotDTO
    {
        public string ReceiptLotId { get; set; }
        public double ImportedQuantity { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public LotStatus ReceiptLotStatus { get; set; }
        public string InventoryReceiptEntryId { get; set; }
        public List<ReceiptSubLotDTO> ReceiptSublots { get; set; }

        public ReceiptLotDTO()
        {
        }

        public ReceiptLotDTO(string receiptLotId, double importedQuantity, List<ReceiptSubLotDTO> receiptSublots, LotStatus receiptLotStatus, string inventoryReceiptEntryId)
        {
            ReceiptLotId = receiptLotId;
            ImportedQuantity = importedQuantity;
            ReceiptSublots = receiptSublots;
            ReceiptLotStatus = receiptLotStatus;
            InventoryReceiptEntryId = inventoryReceiptEntryId;
        }
    }
}
