
namespace WMS.Infrastructure.Repositories.InventoryReceiptRepositories
{
    public class InventoryReceiptEntryRepository : BaseRepository, IInventoryReceiptEntryRepository
    {
        public InventoryReceiptEntryRepository(WMSDbContext context) : base(context)
        {
        }

        public async Task<List<InventoryReceiptEntry>> GetAllAsync()
        {
            return await _context.InventoryReceiptEntries.ToListAsync();
        }

        public async Task<InventoryReceiptEntry> GetById(string inventoryReceiptEntryId)
        {
            var entry = await _context.InventoryReceiptEntries
                .Include(s => s.receiptLot)
                    .ThenInclude(s => s.receiptSublots)
                .FirstOrDefaultAsync(x => x.inventoryReceiptEntryId== inventoryReceiptEntryId);

            return entry;
        }
    }
}
