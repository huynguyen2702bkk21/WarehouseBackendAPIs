namespace WMS.Application.Commands.InventoryIssueCommands.InventoryIssues
{
    public class CreateInventoryIssueCommand : IRequest<bool>
    {
        public string InventoryIssueId { get; set; }
        public DateTime IssueDate { get; set; }
        public string IssueStatus { get; set; }
        public string CustomerId { get; set; }
        public string PersonId { get; set; }
        public string WarehouseId { get; set; }
        public List<CreateInventoryIssueEntryCommand> Entries { get; set; }

        public CreateInventoryIssueCommand(string inventoryIssueId, DateTime issueDate, string issueStatus, string customerId, string personId, string warehouseId, List<CreateInventoryIssueEntryCommand> entries)
        {
            InventoryIssueId = inventoryIssueId;
            IssueDate = issueDate;
            IssueStatus = issueStatus;
            CustomerId = customerId;
            PersonId = personId;
            WarehouseId = warehouseId;
            Entries = entries;
        }
    }
}
