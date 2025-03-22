namespace WMS.Application.Commands.InventoryIssueCommands.InventoryIssues
{
    public class UpdateInventoryIssueCommand : IRequest<bool>
    {
        public string InventoryIssueId { get; set; }
        public string CustomerId { get; set; }
        public string PersonId { get; set; }
        public string WarehouseId { get; set; }

        public UpdateInventoryIssueCommand(string inventoryIssueId, string customerId, string personId, string warehouseId)
        {
            InventoryIssueId = inventoryIssueId;
            CustomerId = customerId;
            PersonId = personId;
            WarehouseId = warehouseId;
        }
    }
}
