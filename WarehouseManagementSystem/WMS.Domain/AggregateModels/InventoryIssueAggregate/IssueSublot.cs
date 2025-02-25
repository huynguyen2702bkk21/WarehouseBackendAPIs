namespace WMS.Domain.AggregateModels.InventoryIssueAggregate
{
    public class IssueSublot : Entity, IAggregateRoot
    {
        [Key]
        public string issueSublotId { get; set; }

        public double requestedQuantity { get; set; }

        [ForeignKey("materialSublotId")]
        public string sublotId { get; set; }
        public MaterialSubLot materialSublot { get; set; }

        [ForeignKey("issueLotId")]
        public string issueLotId { get; set; }
        public IssueLot issueLot { get; set; }
    }
}
