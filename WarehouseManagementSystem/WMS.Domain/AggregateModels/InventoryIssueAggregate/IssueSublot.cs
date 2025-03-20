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

        public IssueSublot()
        {
        }

        public IssueSublot(string issueSublotId, double requestedQuantity, string materialSublotId, string issueLotId)
        {
            this.issueSublotId = issueSublotId;
            this.requestedQuantity = requestedQuantity;
            this.sublotId = materialSublotId;
            this.issueLotId = issueLotId;
        }

        public void Update(double requestedQuantity, string materialSubLotId)
        {
            this.requestedQuantity = requestedQuantity;
            this.sublotId = materialSubLotId;

        }



    }
}
