using WMS.Application.Commands.InventoryIssueCommands.InventoryIssues;
using WMS.Application.Commands.InventoryIssueCommands.IssueLots;

namespace WMS.Application.Commands.InventoryIssueCommands.InventoryIssueEntries
{
    public class CreateInventoryIssueEntryCommand : IRequest<bool>
    {
        public string InventoryIssueEntryId { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public double RequestedQuantity { get; set; }
        public string Note { get; set; }
        public string MaterialId { get; set; }
        public string InventoryIssueId { get; set; }
        public string IssueLotId { get; set; }
        public CreateIssueLotCommand IssueLot { get; set; }

        public CreateInventoryIssueEntryCommand(string inventoryIssueEntryId, string purchaseOrderNumber, double requestedQuantity, string note, string materialId, string inventoryIssueId, string issueLotId, CreateIssueLotCommand issueLot)
        {
            InventoryIssueEntryId = inventoryIssueEntryId;
            PurchaseOrderNumber = purchaseOrderNumber;
            RequestedQuantity = requestedQuantity;
            Note = note;
            MaterialId = materialId;
            InventoryIssueId = inventoryIssueId;
            IssueLotId = issueLotId;
            IssueLot = issueLot;
        }
    }
}
