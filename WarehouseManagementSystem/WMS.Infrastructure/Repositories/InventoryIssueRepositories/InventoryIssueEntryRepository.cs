
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
    }
}
