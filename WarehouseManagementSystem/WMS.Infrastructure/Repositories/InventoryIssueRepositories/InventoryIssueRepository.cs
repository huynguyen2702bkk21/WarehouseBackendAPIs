namespace WMS.Infrastructure.Repositories.InventoryIssueRepositories
{
    public class InventoryIssueRepository : BaseRepository, IInventoryIssueRepository
    {
        public InventoryIssueRepository(WMSDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<InventoryIssue>> GetAllAsync()
        {
            return await _context.InventoryIssues.ToListAsync();
        }

        public async Task<InventoryIssue> GetByIdAsync(string inventoryIssueId)
        {
            var inventoryIssue = await _context.InventoryIssues
                .FirstOrDefaultAsync(x => x.inventoryIssueId == inventoryIssueId);

            if (inventoryIssue == null)
            {
                return null;
            }

            var inventoryIssueEntries = await _context.InventoryIssueEntries
                .Where(x => x.inventoryIssueId == inventoryIssueId)
                .ToListAsync();

            inventoryIssue.entries = inventoryIssueEntries;

            return inventoryIssue;
        }
    }
}
