namespace WMS.Domain.AggregateModels.InventoryIssueAggregate
{
    public class InventoryIssue : Entity, IAggregateRoot
    {
        public string inventoryIssueId { get; set; }
        public DateTime issueDate { get; set; }
        public IssueStatus issueStatus { get; set; }

        public string customerId { get; set; }
        public Customer customer { get; set; }

        public string employeeId { get; set; }
        public Employee issuedBy { get; set; }

        public string warehouseId { get; set; }
        public Warehouse warehouse { get; set; }

        public List<InventoryIssueEntry> entries { get; set; }
        
    }
}
