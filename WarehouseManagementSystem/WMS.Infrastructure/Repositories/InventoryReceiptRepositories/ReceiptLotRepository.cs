
namespace WMS.Infrastructure.Repositories.InventoryReceiptRepositories
{
    public class ReceiptLotRepository : BaseRepository, IReceiptLotRepository
    {
        public ReceiptLotRepository(WMSDbContext context) : base(context)
        {
        }

        public async Task<List<ReceiptLot>> GetAllAsync()
        {
            return await _context.ReceiptLots.ToListAsync();
        }

        public async Task<ReceiptLot> GetById(string Id)
        {
            return await _context.ReceiptLots.FirstOrDefaultAsync(x => x.receiptLotId == Id);
        }

        public async Task<ReceiptLot> GetByIdAsnc(string lotNumber)
        {
            var receiptLot = await _context.ReceiptLots
                .Include(s => s.receiptSublots)
                .FirstOrDefaultAsync(x => x.receiptLotId == lotNumber);

            return receiptLot;

        }
    }
}
