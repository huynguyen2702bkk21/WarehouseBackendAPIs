
namespace WMS.Infrastructure.Repositories.InventoryReceiptRepositories
{
    public class InventoryReceiptRepository : BaseRepository, IInventoryReceiptRepository
    {
        public InventoryReceiptRepository(WMSDbContext context) : base(context)
        {
        }

        public void Create(InventoryReceipt inventoryReceipt)
        {
            _context.InventoryReceipts.Add(inventoryReceipt);
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
