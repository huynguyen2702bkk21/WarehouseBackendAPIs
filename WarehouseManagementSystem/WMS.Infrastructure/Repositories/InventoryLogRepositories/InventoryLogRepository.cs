using DocumentFormat.OpenXml.Vml.Office;
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

        public async Task<List<InventoryLog>> GetInventoryLogByLotNumberAndStatus(string lotNumber, string status)
        {
            if (!Enum.TryParse<TransactionType>(status, out var transactionType))
            {
                throw new Exception($"Invalid LotStatus status: {status}");
            }

            var inventoryLogs = new List<InventoryLog>();

            switch (transactionType)
            {
                case TransactionType.Issue:
                    inventoryLogs = await _context.InventoryLogs
                        .Where(x => x.lotNumber == lotNumber && x.transactionType == TransactionType.Issue)
                        .ToListAsync();
                    break;
                   
                case TransactionType.Receipt:
                    inventoryLogs = await _context.InventoryLogs
                        .Where(x => x.lotNumber == lotNumber && x.transactionType == TransactionType.Receipt)
                        .ToListAsync();
                    break;

                default:
                    inventoryLogs = await _context.InventoryLogs
                        .Where(x => x.lotNumber == lotNumber)
                        .OrderByDescending(x => x.transactionDate)
                        .ToListAsync();
                    break;

            }

            return inventoryLogs;

        }



    }
}
