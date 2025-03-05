
namespace WMS.Infrastructure.Repositories.InventoryIssueRepositories
{
    public class IssueLotRepository : BaseRepository, IIssueLotRepository
    {
        public IssueLotRepository(WMSDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<IssueLot>> GetAllIssueLotsAsync()
        {
            return await _context.IssueLots.ToListAsync();
        }

        public async Task<IssueLot> GetIssueLotByIdAsync(string id)
        {
            var issueLot = await _context.IssueLots
                .Include(x => x.issueSublots)
                .ThenInclude(x => x.materialSublot)
                .FirstOrDefaultAsync(x => x.issueLotId== id);

            return issueLot;


        }
    }
}
