namespace WMS.Domain.InterfaceRepositories.IStorage
{
    public interface IWarehouseRepository : IRepository<Warehouse>
    {
        Task<List<Warehouse>> GetAllWarehouses();
        Task<Warehouse> GetWarehouseById(string warehouseId);
        Task<Warehouse> GetWarehouseByIdAsync(string id);
        void Create(Warehouse warehouse);
        void Delete(Warehouse warehouse);
        void Update(Warehouse warehouse);

    }
}
