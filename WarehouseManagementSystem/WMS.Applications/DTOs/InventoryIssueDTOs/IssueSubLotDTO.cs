namespace WMS.Application.DTOs.InventoryIssueDTOs
{
    public class IssueSubLotDTO
    {
        public string IssueSublotId { get; set; }
        public double RequestedQuantity { get; set; }
        public MaterialSubLotDTO MaterialSublot { get; set; }
        public string IssueLotId { get; set; }

        public IssueSubLotDTO(string issueSublotId, double requestedQuantity, MaterialSubLotDTO materialSublot, string issueLotId)
        {
            IssueSublotId = issueSublotId;
            RequestedQuantity = requestedQuantity;
            MaterialSublot = materialSublot;
            IssueLotId = issueLotId;
        }
    }
}
