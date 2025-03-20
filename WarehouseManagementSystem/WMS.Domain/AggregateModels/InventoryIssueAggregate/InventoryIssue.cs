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
            AddDomainEvent(new MaterialLotsExportedDomainEvent(inventoryIssue, materialLots));

            if (materialLots.Count == 0)
            {
                throw new Exception("MaterialLots is empty, cannot confirm issue.");
            }

            foreach (var lot in materialLots)
            {
                double exisitingQuantity = lot.exisitingQuantity;
                foreach (var entry in inventoryIssue.entries)
                {
                    if (entry.issueLot.materialLotId == lot.lotNumber)
                    {
                        var ChangedQuantity = entry.issueLot.requestedQuantity;
                        
                        AddDomainEvent(new InventoryLogAddedDomainEvent(transactionType: TransactionType.Issue,
                                                                        transactionDate: GetVietnamTime(),
                                                                        previousQuantity: exisitingQuantity,
                                                                        changedQuantity: ChangedQuantity,
                                                                        afterQuantity: exisitingQuantity - ChangedQuantity,
                                                                        note: "",
                                                                        lotNumber: lot.lotNumber,
                                                                        warehouseId: inventoryIssue.warehouseId));

                        exisitingQuantity = exisitingQuantity - ChangedQuantity;

                    }



                }
            }

        }

        private static DateTime GetVietnamTime()
        {
            return TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time"));
        }


    }
}
