namespace WMS.Infrastructure.Repositories.InventoryIssueRepositories
{
    public class InventoryIssueRepository : BaseRepository, IInventoryIssueRepository
    {
        public InventoryIssueRepository(WMSDbContext context) : base(context)
        {
        }

        public void Create(InventoryIssue inventoryIssue)
        {
            _context.InventoryIssues.Add(inventoryIssue);
        }

        public async Task<List<InventoryIssue>> GetAllAsync()
        {
            return await _context.InventoryIssues.ToListAsync();
        }

        public async Task<InventoryIssue> GetByIdAsync(string inventoryIssueId)
        {
            var inventoryIssue = await _context.InventoryIssues
                .Include(x => x.entries)
                    .ThenInclude(x => x.issueLot)
                        .ThenInclude(x => x.issueSublots)
                .FirstOrDefaultAsync(x => x.inventoryIssueId == inventoryIssueId);

            return inventoryIssue;
        }
    }
}
