namespace WMS.Domain.InterfaceRepositories.IInventoryLog
{
    public interface IInventoryLogRepository : IRepository<InventoryLog>
    {
        Task<InventoryLog> GetInventoryLogByLotNumber(string lotNumber);
        void Create(InventoryLog inventoryLog);
    }
}
