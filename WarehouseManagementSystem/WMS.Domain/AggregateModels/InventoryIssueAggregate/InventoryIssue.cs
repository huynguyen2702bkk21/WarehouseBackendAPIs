using WMS.Domain.DomainEvents.InventoryLogEvents;
using WMS.Domain.DomainEvents.MaterialLotDomainEvents;

namespace WMS.Domain.AggregateModels.InventoryIssueAggregate
{
    public class InventoryIssue : Entity, IAggregateRoot
    {
        [Key]
        public string inventoryIssueId { get; set; }

        public DateTime issueDate { get; set; }
        public IssueStatus issueStatus { get; set; }

        [ForeignKey("customerId")]
        public string customerId { get; set; }
        public Customer customer { get; set; }

        [ForeignKey("personId")]
        public string personId { get; set; }
        public Person issuedBy { get; set; }

        [ForeignKey("warehouseId")]
        public string warehouseId { get; set; }
        public Warehouse warehouse { get; set; }

        public List<InventoryIssueEntry> entries { get; set; }

        public InventoryIssue()
        {
        }

        public InventoryIssue(string inventoryIssueId, DateTime issueDate, IssueStatus issueStatus, string customerId, string personId, string warehouseId)
        {
            this.inventoryIssueId = inventoryIssueId;
            this.issueDate = issueDate;
            this.issueStatus = issueStatus;
            this.customerId = customerId;
            this.personId = personId;
            this.warehouseId = warehouseId;
            this.entries = new List<InventoryIssueEntry>();
        }

        public void AddEntry(InventoryIssueEntry issueEntry)
        {
            entries.Add(issueEntry);
        }

        public void Confirm(List<MaterialLot> materialLots, InventoryIssue inventoryIssue)
        {
            foreach(var materialLot in materialLots)
            {
                double requestedQuantity = 0;
                foreach (var entry in inventoryIssue.entries)
                {
                    if (materialLot.lotNumber == entry.issueLot.materialLotId)
                    {
                        requestedQuantity = entry.issueLot.requestedQuantity;
                    }
                }

                AddDomainEvent(new InventoryLogAddedDomainEvent(transactionType: TransactionType.Issue,
                                                                transactionDate: GetVietnamTime(),
                                                                previousQuantity: materialLot.exisitingQuantity,
                                                                changedQuantity: requestedQuantity,
                                                                afterQuantity: materialLot.exisitingQuantity - requestedQuantity,
                                                                note: "",
                                                                lotNumber: materialLot.lotNumber,
                                                                warehouseId: inventoryIssue.warehouseId));
            }

            AddDomainEvent(new MaterialLotsExportedDomainEvent(inventoryIssue, materialLots));

        }

        private static DateTime GetVietnamTime()
        {
            return TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time"));
        }


    }
}
