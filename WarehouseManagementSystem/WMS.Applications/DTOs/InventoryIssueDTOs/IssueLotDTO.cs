namespace WMS.Application.DTOs.InventoryIssueDTOs
{
    public class IssueLotDTO
    {
        public string IssueLotId { get; set; }
        public double RequestedQuantity { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public LotStatus IssueLotStatus { get; set; }
        public string MaterialLotId { get; set; }
        public string InventoryIssueEntryId { get; set; }
        public List<IssueSubLotDTO> IssueSublots { get; set; }

        public IssueLotDTO()
        {
        }

        public IssueLotDTO(string issueLotId, double requestedQuantity, List<IssueSubLotDTO> issueSublots, LotStatus issueLotStatus, string materialLotId, string inventoryIssueEntryId)
        {
            IssueLotId = issueLotId;
            RequestedQuantity = requestedQuantity;
            IssueSublots = issueSublots;
            IssueLotStatus = issueLotStatus;
            MaterialLotId = materialLotId;
            InventoryIssueEntryId = inventoryIssueEntryId;
        }
    }
}
