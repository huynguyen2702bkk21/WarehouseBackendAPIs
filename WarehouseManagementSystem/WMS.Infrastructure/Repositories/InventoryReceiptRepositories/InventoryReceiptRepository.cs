
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
                .FirstOrDefaultAsync(x => x.inventoryReceiptId == inventoryReceiptId);

            if (inventoryReceipt == null)
            {
                return null;
            }

            var inventoryReceiptEntries = await _context.InventoryReceiptEntries
                .Where(x => x.InventoryReceiptId == inventoryReceiptId)
                .ToListAsync();

            inventoryReceipt.entries = inventoryReceiptEntries;

            return inventoryReceipt;
        }
    }
}
