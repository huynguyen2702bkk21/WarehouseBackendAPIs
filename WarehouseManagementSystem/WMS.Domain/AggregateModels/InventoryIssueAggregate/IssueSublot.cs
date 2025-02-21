namespace WMS.Domain.AggregateModels.InventoryIssueAggregate
{
    public class IssueSublot : Entity, IAggregateRoot
    {
        public string issueSublotId { get; set; }
        public double requestedQuantity { get; set; }

        public string sublotId { get; set; }
        public MaterialSubLot materialSublot { get; set; }

        public string issueLotId { get; set; }
    }
}
