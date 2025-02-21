namespace WMS.Domain.AggregateModels.InventoryIssueAggregate
{
    public class InventoryIssueEntry : Entity, IAggregateRoot
    {
        public string inventoryIssueEntryId { get; set; }
        public string purchaseOrderNumber { get; set; }

        public double requestedQuantity { get; set; }
        public string note { get; set; }

        public string issueLotId { get; set; }
        public IssueLot issueLot { get; set; }

        public string inventoryIssueId { get; set; }
        public InventoryIssue inventoryIssue { get; set; }
    }
}
