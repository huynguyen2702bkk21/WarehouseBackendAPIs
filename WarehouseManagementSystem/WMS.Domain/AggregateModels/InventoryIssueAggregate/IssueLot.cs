namespace WMS.Domain.AggregateModels.InventoryIssueAggregate
{
    public class IssueLot : Entity, IAggregateRoot
    {
        public string issueLotId { get; set; }

        public double requestedQuantity { get; set; }
        public List<IssueSublot> issueSublots { get; set; }
        public LotStatus lotStatus { get; set; }

        public string materialId { get; set; }
        public Material material { get; set; }

        public string inventoryIssueEntryId { get; set; }
        public InventoryIssueEntry inventoryIssueEntry { get; set; }

    }
}
