namespace WMS.Domain.AggregateModels.InventoryIssueAggregate
{
    public class IssueLot : Entity, IAggregateRoot
    {
        public string issueLotId { get; set; }
        public double requestedQuantity { get; set; }

        public string lotNumber { get; set; }
        public MaterialLot materialLot { get; set; }

        public List<IssueSublot> issueSublots { get; set; }

        public string inventoryIssueEntryId { get; set; }

    }
}
