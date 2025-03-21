namespace WMS.Domain.InterfaceRepositories.IInventoryLog
{
    public interface IInventoryLogRepository : IRepository<InventoryLog>
    {
        Task<List<InventoryLog>> GetInventoryLogByLotNumberAndStatus(string lotNumber, string status);
        void Create(InventoryLog inventoryLog);
    }
}
