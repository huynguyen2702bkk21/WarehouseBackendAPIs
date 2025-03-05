
namespace WMS.Infrastructure.Repositories.InventoryReceiptRepositories
{
    public class InventoryReceiptRepository : BaseRepository, IInventoryReceiptRepository
    {
        public InventoryReceiptRepository(WMSDbContext context) : base(context)
        {
        }

        public async Task<List<InventoryReceipt>> GetAllAsync()
        {
            return await _context.InventoryReceipts.ToListAsync();
        }

        public async Task<InventoryReceipt> GetByIdAsync(string inventoryReceiptId)
        {
            var inventoryReceipt = await _context.InventoryReceipts
                .Include(s => s.entries)
                .FirstOrDefaultAsync(x => x.inventoryReceiptId == inventoryReceiptId);

            return inventoryReceipt;
        }
    }
}
