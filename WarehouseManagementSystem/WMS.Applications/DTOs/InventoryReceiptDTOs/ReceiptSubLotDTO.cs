namespace WMS.Application.DTOs.InventoryReceiptDTOs
{
    public class ReceiptSubLotDTO
    {
        public string ReceiptSublotId { get; set; }
        public double ImportedQuantity { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public LotStatus SubLotStatus { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public UnitOfMeasure UnitOfMeasure { get; set; }
        public string LocationId { get; set; }
        public string ReceiptLotId { get; set; }

        public ReceiptSubLotDTO(string receiptSublotId, double importedQuantity, LotStatus subLotStatus, UnitOfMeasure unitOfMeasure, string locationId, string receiptLotId)
        {
            ReceiptSublotId = receiptSublotId;
            ImportedQuantity = importedQuantity;
            SubLotStatus = subLotStatus;
            UnitOfMeasure = unitOfMeasure;
            LocationId = locationId;
            ReceiptLotId = receiptLotId;
        }
    }
}
