
namespace WMS.Infrastructure.Repositories.InventoryIssueRepositories
{
    public class InventoryIssueEntryRepository : BaseRepository, IInventoryIssueEntryRepository
    {
        public InventoryIssueEntryRepository(WMSDbContext context) : base(context)
        {
        }

        public async Task<List<InventoryIssueEntry>> GetAllInventoryIssueEntriesAsync()
        {
            var inventoryIssueEntries = await _context.InventoryIssueEntries
                .Include(x => x.issueLot)
                .ToListAsync();

            return inventoryIssueEntries;
        }

        public async Task<InventoryIssueEntry> GetInventoryIssueEntryByIdAsync(string InventoryIssueEntryId)
        {
            var inventoryIssueEntry =  await _context.InventoryIssueEntries
                .Include(x => x.issueLot)
                    .ThenInclude(x => x.issueSublots)
                        .ThenInclude(x => x.materialSublot)
                .FirstOrDefaultAsync(x => x.inventoryIssueEntryId == InventoryIssueEntryId);

            return inventoryIssueEntry;
        }

        public async Task<List<InventoryIssue>> GetInventoryIssuesByEntryIds(List<string> entryId)
        {
            var inventoryIssues = await _context.InventoryIssues
                .Include(s => s.entries)
                    .ThenInclude(s => s.issueLot)
                        .ThenInclude(s => s.issueSublots)
                .Where(x => x.entries.Any(y => entryId.Contains(y.inventoryIssueEntryId)))
                .ToListAsync();

            return inventoryIssues;
        }

    }
}
