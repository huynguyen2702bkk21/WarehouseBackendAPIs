namespace WMS.Domain.AggregateModels.InventoryIssueAggregate
{
    public class IssueSublot : Entity, IAggregateRoot
    {
        [Key]
        public string issueSublotId { get; set; }

        public double requestedQuantity { get; set; }
        public LotStatus subLotStatus { get; set; }
        public UnitOfMeasure unitOfMeasure { get; set; }

        [ForeignKey("locationId")]
        public string locationId { get; set; }
        public Location location { get; set; }

        [ForeignKey("issueLotId")]
        public string issueLotId { get; set; }
        public IssueLot issueLot { get; set; }
    }
}
