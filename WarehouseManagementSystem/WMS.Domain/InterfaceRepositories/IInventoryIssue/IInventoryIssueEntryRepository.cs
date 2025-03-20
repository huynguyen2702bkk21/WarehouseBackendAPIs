namespace WMS.Domain.InterfaceRepositories.IInventoryIssue
{
    public interface IInventoryIssueEntryRepository : IRepository<InventoryIssueEntry>
    {
        Task<List<InventoryIssueEntry>> GetAllInventoryIssueEntriesAsync();
        Task<InventoryIssueEntry> GetInventoryIssueEntryByIdAsync(string InventoryIssueEntryId);
    }
}
