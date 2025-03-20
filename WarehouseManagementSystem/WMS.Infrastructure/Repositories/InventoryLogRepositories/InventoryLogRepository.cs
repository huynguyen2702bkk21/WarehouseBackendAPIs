using WMS.Domain.InterfaceRepositories.IInventoryLog;

namespace WMS.Infrastructure.Repositories.InventoryLogRepositories
{
    public class InventoryLogRepository : BaseRepository, IInventoryLogRepository
    {
        public InventoryLogRepository(WMSDbContext context) : base(context)
        {
        }

        public void Create(InventoryLog inventoryLog)
        {
            _context.InventoryLogs.AddRange(inventoryLog);
        }

        public async Task<List<InventoryLog>> GetInventoryLogByLotNumber(string lotNumber)
        {
            var inventoryLogs = await _context.InventoryLogs
                .Where(x => x.lotNumber == lotNumber)
                .ToListAsync();

            inventoryLogs = inventoryLogs.OrderByDescending(x => x.transactionDate).ToList();


            return inventoryLogs;
        }



    }
}
