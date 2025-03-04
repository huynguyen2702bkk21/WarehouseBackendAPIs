namespace WMS.Application.DTOs.InventoryReceiptDTOs
{
    public class InventoryReceiptDTO
    {
        public string InventoryReceiptId { get; set; }
        public DateTime ReceiptDate { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ReceiptStatus ReceiptStatus { get; set; }
        public string SupplierName { get; set; }
        public string PersonName { get; set; }
        public string WarehouseName { get; set; }
        public List<InventoryReceiptEntryDTO> Entries { get; set; }

        public InventoryReceiptDTO()
        {
        }

        public InventoryReceiptDTO(string inventoryReceiptId, DateTime receiptDate, ReceiptStatus receiptStatus, string supplierName, string personName, string warehouseName, List<InventoryReceiptEntryDTO> entries)
        {
            InventoryReceiptId = inventoryReceiptId;
            ReceiptDate = receiptDate;
            ReceiptStatus = receiptStatus;
            SupplierName = supplierName;
            PersonName = personName;
            WarehouseName = warehouseName;
            Entries = entries;
        }

        public void MapName(string personName, string warehouseName, string supplierName)
        {
            PersonName = personName;
            WarehouseName = warehouseName;
            SupplierName = supplierName;
        }

    }
}
