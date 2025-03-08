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

        public async Task<InventoryLog> GetInventoryLogByLotNumber(string lotNumber)
        {
            var inventoryLog = await _context.InventoryLogs
                .Include(s => s.materialLot)
                .Include(s => s.warehouse)
                .FirstOrDefaultAsync(x => x.lotNumber == lotNumber);

            return inventoryLog;
        }
    }
}
