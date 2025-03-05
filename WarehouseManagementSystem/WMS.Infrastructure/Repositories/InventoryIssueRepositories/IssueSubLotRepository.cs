
namespace WMS.Infrastructure.Repositories.InventoryIssueRepositories
{
    public class IssueSubLotRepository : BaseRepository, IIssueSubLotRepository
    {
        public IssueSubLotRepository(WMSDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<IssueSublot>> GetAllAsync()
        {
            return await _context.IssueSublots.ToListAsync();
             
        }

        public async Task<IssueSublot> GetByIdAsync(string IssueSubLotId)
        {
            return await _context.IssueSublots.Where(x => x.issueSublotId== IssueSubLotId).FirstOrDefaultAsync();
        }
    }
}
