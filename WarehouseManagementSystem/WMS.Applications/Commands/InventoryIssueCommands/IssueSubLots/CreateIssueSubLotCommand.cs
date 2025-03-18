namespace WMS.Application.Commands.InventoryIssueCommands.IssueSubLots
{
    public class CreateIssueSubLotCommand : IRequest<bool>
    {
        public string IssueSublotId { get; set; }
        public double RequestedQuantity { get; set; }
        public string MaterialSublotId { get; set; }
        public string IssueLotId { get; set; }

        public CreateIssueSubLotCommand(string issueSublotId, double requestedQuantity, string materialSublotId, string issueLotId)
        {
            IssueSublotId = issueSublotId;
            RequestedQuantity = requestedQuantity;
            MaterialSublotId = materialSublotId;
            IssueLotId = issueLotId;
        }
    }
}
