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

        [ForeignKey("employeeId")]
        public string employeeId { get; set; }
        public Employee issuedBy { get; set; }

        [ForeignKey("warehouseId")]
        public string warehouseId { get; set; }
        public Warehouse warehouse { get; set; }

        public List<InventoryIssueEntry> entries { get; set; }
        
    }
}
