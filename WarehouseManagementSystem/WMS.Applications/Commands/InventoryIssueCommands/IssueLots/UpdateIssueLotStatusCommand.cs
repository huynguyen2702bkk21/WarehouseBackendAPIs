namespace WMS.Application.Commands.InventoryIssueCommands.IssueLots
{
    public class UpdateIssueLotStatusCommand : IRequest<bool>
    {
        public string InventoryIssueId { get; set; }
        public string InventoryIssueEntryId { get; set; }
        public string IssueLotId { get; set; }
        public string IssueLotStatus { get; set; }

        public UpdateIssueLotStatusCommand(string inventoryIssueId, string inventoryIssueEntryId, string issueLotId, string issueLotStatus)
        {
            InventoryIssueId = inventoryIssueId;
            InventoryIssueEntryId = inventoryIssueEntryId;
            IssueLotId = issueLotId;
            IssueLotStatus = issueLotStatus;
        }
    }
}
