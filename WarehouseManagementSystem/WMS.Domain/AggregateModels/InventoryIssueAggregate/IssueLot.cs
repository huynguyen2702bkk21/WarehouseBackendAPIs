﻿namespace WMS.Domain.AggregateModels.InventoryIssueAggregate
{
    public class IssueLot : Entity, IAggregateRoot
    {
        [Key]
        public string issueLotId { get; set; }

        public double requestedQuantity { get; set; }
        public List<IssueSublot> issueSublots { get; set; }
        public LotStatus lotStatus { get; set; }

        [ForeignKey("inventoryIssueEntryId")]
        public string inventoryIssueEntryId { get; set; }
        public InventoryIssueEntry inventoryIssueEntry { get; set; }

    }
}
