namespace WMS.Domain.InterfaceRepositories.IInventoryIssue
{
    public interface IInventoryIssueEntryRepository : IRepository<InventoryIssueEntry>
    {
        Task<List<InventoryIssueEntry>> GetAllInventoryIssueEntriesAsync();
        Task<InventoryIssueEntry> GetInventoryIssueEntryByIdAsync(string InventoryIssueEntryId);
        Task<List<InventoryIssue>> GetInventoryIssuesByEntryIds(List<string> entryId);
    }
}
