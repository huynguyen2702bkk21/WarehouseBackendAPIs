
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
            var issueLot = await _context.IssueLots.FirstOrDefaultAsync(x => x.issueLotId== id);
            if (issueLot == null)
            {
                return null;
            }

            var issueSubLots = await _context.IssueSublots.Where(x => x.issueLotId == issueLot.issueLotId).ToListAsync();
            if (issueSubLots != null)
            {
                issueLot.issueSublots= issueSubLots;
            }

            foreach (var issueSubLot in issueLot.issueSublots)
            {
                var materialSubLot = await _context.MaterialSubLots.FirstOrDefaultAsync(x => x.subLotId== issueSubLot.sublotId);
                if (materialSubLot != null)
                {
                    issueSubLot.materialSublot= materialSubLot;
                }
            }

            return issueLot;


        }
    }
}
