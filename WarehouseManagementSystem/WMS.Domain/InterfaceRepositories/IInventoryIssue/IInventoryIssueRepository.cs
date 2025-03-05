namespace WMS.Domain.InterfaceRepositories.IInventoryIssue
{
    public interface IInventoryIssueRepository : IRepository<InventoryIssue>
    {
        Task<IEnumerable<InventoryIssue>> GetAllAsync();
        Task<InventoryIssue> GetByIdAsync(string inventoryIssueId);
    }
}
