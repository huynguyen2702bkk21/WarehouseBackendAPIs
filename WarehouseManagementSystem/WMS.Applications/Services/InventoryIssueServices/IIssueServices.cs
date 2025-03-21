namespace WMS.Application.Services.InventoryIssueServices
{
    public interface IIssueServices
    {
        Task<InventoryIssue> CreateNewInventoryIssue(CreateInventoryIssueCommand request);
        Task UpdateMaterialLot(InventoryIssue inventoryIssue);
        Task<InventoryIssueEntry> CreateEntry(CreateInventoryIssueEntryCommand request);
        Task UpdateIssueEntries(UpdateInventoryIssueEntryCommand request);


    }
}
