
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

        public void Delete(InventoryReceipt inventoryReceipt)
        {
            _context.InventoryReceipts.Remove(inventoryReceipt);
        }

        public async Task<List<InventoryReceipt>> GetAllAsync()
        {
            return await _context.InventoryReceipts.ToListAsync();
        }

        public async Task<InventoryReceipt> GetByIdAsync(string inventoryReceiptId)
        {
            var inventoryReceipt = await _context.InventoryReceipts
                .Include(s => s.entries)
                    .ThenInclude(s => s.receiptLot)
                        .ThenInclude(s => s.receiptSublots)
                .FirstOrDefaultAsync(x => x.inventoryReceiptId == inventoryReceiptId);

            return inventoryReceipt;
        }

        public async Task<List<InventoryReceipt>> GetInventoryReceiptsByEntryIds(List<string> entryId)
        {
            var inventoryReceipt = await _context.InventoryReceipts
                .Include(s => s.entries)
                    .ThenInclude(s => s.receiptLot)
                        .ThenInclude(s => s.receiptSublots)
                .Where(x => x.entries.Any(y => entryId.Contains(y.inventoryReceiptEntryId)))
                .ToListAsync();

            return inventoryReceipt;
        }
    }
}
