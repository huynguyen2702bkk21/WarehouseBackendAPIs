namespace WMS.Application.DTOs.InventoryIssueDTOs
{
    public class InventoryIssueDTO
    {
        public string InventoryIssueId { get; set; }
        public DateTime IssueDate { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public IssueStatus IssueStatus { get; set; }
        public string CustomerName { get; set; }
        public string PersonName { get; set; }
        public string WarehouseName { get; set; }
        public List<InventoryIssueEntryDTO> Entries { get; set; }

        public InventoryIssueDTO()
        {
        }

        public InventoryIssueDTO(string inventoryIssueId, DateTime issueDate, IssueStatus issueStatus, string customerName, string personName, string warehouseName, List<InventoryIssueEntryDTO> entries)
        {
            InventoryIssueId = inventoryIssueId;
            IssueDate = issueDate;
            IssueStatus = issueStatus;
            CustomerName = customerName;
            PersonName = personName;
            WarehouseName = warehouseName;
            Entries = entries;
        }

        public void MapName(string customerName, string personName, string warehouseName)
        {
            CustomerName = customerName;
            PersonName = personName;
            WarehouseName = warehouseName;
        }

    }
}
