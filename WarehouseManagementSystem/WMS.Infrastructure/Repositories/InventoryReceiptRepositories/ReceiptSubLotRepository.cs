
namespace WMS.Infrastructure.Repositories.InventoryReceiptRepositories
{
    public class ReceiptSubLotRepository : BaseRepository, IReceiptSubLotRepository
    {

        public ReceiptSubLotRepository(WMSDbContext context) : base(context)
        {
        }

        public async Task<List<ReceiptSublot>> GetAllAsync()
        {
            return await _context.ReceiptSublots.ToListAsync();
        }

        public async Task<ReceiptSublot> GetByIdAsync(string receiptSublotId)
        {
            return await _context.ReceiptSublots.FirstOrDefaultAsync(x => x.receiptSublotId== receiptSublotId);
        }

        public Task<List<ReceiptSublot>> GetSublotsByLotId(string lotId)
        {
            return _context.ReceiptSublots.Where(x => x.receiptLotId == lotId).ToListAsync();
        }
    }
}
