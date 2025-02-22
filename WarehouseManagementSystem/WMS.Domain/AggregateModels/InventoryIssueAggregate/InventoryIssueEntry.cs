namespace WMS.Domain.AggregateModels.InventoryIssueAggregate
{
    public class InventoryIssueEntry : Entity, IAggregateRoot
    {
        [Key]
        public string inventoryIssueEntryId { get; set; }

        public string purchaseOrderNumber { get; set; }
        public double requestedQuantity { get; set; }
        public string note { get; set; }


        [ForeignKey("materialId")]
        public string materialId { get; set; }
        public Material material { get; set; }

        [ForeignKey("issueLotId")]
        public string issueLotId { get; set; }
        public IssueLot issueLot { get; set; }

        [ForeignKey("inventoryIssueId")]
        public string inventoryIssueId { get; set; }
        public InventoryIssue inventoryIssue { get; set; }
    }
}
