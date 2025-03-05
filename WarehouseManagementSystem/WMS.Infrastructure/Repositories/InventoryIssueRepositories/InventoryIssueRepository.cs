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
                .Include(x => x.entries)
                .FirstOrDefaultAsync(x => x.inventoryIssueId == inventoryIssueId);

            return inventoryIssue;
        }
    }
}
