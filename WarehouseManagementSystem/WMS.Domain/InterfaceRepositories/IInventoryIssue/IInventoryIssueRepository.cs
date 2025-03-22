namespace WMS.Domain.InterfaceRepositories.IInventoryIssue
{
    public interface IInventoryIssueRepository : IRepository<InventoryIssue>
    {
        Task<List<InventoryIssue>> GetAllAsync();
        Task<InventoryIssue> GetByIdAsync(string inventoryIssueId);
        void Create(InventoryIssue inventoryIssue);
        void Delete(InventoryIssue inventoryIssue);
    }
}
