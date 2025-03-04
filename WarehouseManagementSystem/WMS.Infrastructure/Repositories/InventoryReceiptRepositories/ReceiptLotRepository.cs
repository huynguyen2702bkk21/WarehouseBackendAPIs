
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
            var receiptLot = await _context.ReceiptLots.FirstOrDefaultAsync(x => x.receiptLotId == lotNumber);
            if (receiptLot == null)
            {
                return null;
            }

            var sublotReceipts = await _context.ReceiptSublots.Where(x => x.receiptLotId == lotNumber).ToListAsync();  

            receiptLot.receiptSublots= sublotReceipts;

            return receiptLot;

        }
    }
}
