namespace WMS.Domain.InterfaceRepositories.IInventoryIssue
{
    public interface IInventoryIssueEntryRepository : IRepository<InventoryIssueEntry>
    {
        Task<IEnumerable<InventoryIssueEntry>> GetAllInventoryIssueEntriesAsync();
        Task<InventoryIssueEntry> GetInventoryIssueEntryByIdAsync(string InventoryIssueEntryId);
    }
}
