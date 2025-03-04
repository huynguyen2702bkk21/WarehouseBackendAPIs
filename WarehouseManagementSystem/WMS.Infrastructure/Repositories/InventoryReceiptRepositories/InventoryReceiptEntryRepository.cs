
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
            return await _context.InventoryReceiptEntries.FirstOrDefaultAsync(x => x.inventoryReceiptEntryId== inventoryReceiptEntryId);
        }
    }
}
