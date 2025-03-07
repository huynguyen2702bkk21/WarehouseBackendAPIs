
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
            var inventoryIssueEntry =  await _context.InventoryIssueEntries
                .Include(x => x.issueLot)
                .FirstOrDefaultAsync(x => x.inventoryIssueEntryId == InventoryIssueEntryId);

            var issuSubLots = await _context.IssueSublots
                .Where(x => x.issueLotId == inventoryIssueEntry.issueLotId)
                .Include(s => s.materialSublot)
                .ToListAsync();

            inventoryIssueEntry.issueLot.issueSublots = issuSubLots;

            return inventoryIssueEntry;
        }
    }
}
