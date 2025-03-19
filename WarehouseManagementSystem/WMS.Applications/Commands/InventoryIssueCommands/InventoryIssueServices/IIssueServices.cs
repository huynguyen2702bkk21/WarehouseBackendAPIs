namespace WMS.Application.Commands.InventoryIssueCommands.InventoryIssueServices
{
    public interface IIssueServices
    {
        Task<InventoryIssue> CreateNewInventoryIssue(CreateInventoryIssueCommand request);
        Task UpdateMaterialLot(InventoryIssue inventoryIssue);


    }
}
