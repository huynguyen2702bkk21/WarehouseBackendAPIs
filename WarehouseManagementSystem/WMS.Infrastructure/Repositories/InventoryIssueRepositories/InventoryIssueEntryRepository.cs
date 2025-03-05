
namespace WMS.Infrastructure.Repositories.InventoryIssueRepositories
{
    public class InventoryIssueEntryRepository : BaseRepository, IInventoryIssueEntryRepository
    {
        public InventoryIssueEntryRepository(WMSDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<InventoryIssueEntry>> GetAllInventoryIssueEntriesAsync()
        {
            var inventoryIssueEntries = await _context.InventoryIssueEntries
                .Include(x => x.issueLot)
                .ToListAsync();

            return inventoryIssueEntries;
        }

        public async Task<InventoryIssueEntry> GetInventoryIssueEntryByIdAsync(string InventoryIssueEntryId)
        {
            return await _context.InventoryIssueEntries.FirstOrDefaultAsync(x => x.inventoryIssueEntryId == InventoryIssueEntryId);
        }
    }
}
