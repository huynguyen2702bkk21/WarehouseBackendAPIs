using WMS.Application.Commands.InventoryIssueCommands.IssueSubLots;

namespace WMS.Application.Commands.InventoryIssueCommands.IssueLots
{
    public class CreateIssueLotCommand : IRequest<bool>
    {
        public string IssueLotId { get; set; }
        public double RequestedQuantity { get; set; }
        public string IssueLotStatus { get; set; }
        public string MaterialLotId { get; set; }
        public string InventoryIssueEntryId { get; set; }
        public List<CreateIssueSubLotCommand> IssueSublots { get; set; }

        public CreateIssueLotCommand(string issueLotId, double requestedQuantity, string issueLotStatus, string materialLotId, string inventoryIssueEntryId, List<CreateIssueSubLotCommand> issueSublots)
        {
            IssueLotId = issueLotId;
            RequestedQuantity = requestedQuantity;
            IssueLotStatus = issueLotStatus;
            MaterialLotId = materialLotId;
            InventoryIssueEntryId = inventoryIssueEntryId;
            IssueSublots = issueSublots;
        }
    }
}
