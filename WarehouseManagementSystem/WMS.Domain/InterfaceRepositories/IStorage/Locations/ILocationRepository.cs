namespace WMS.Domain.InterfaceRepositories.IStorage
{
    public interface ILocationRepository : IRepository<Location>
    {
        Task<List<Location>> GetAllLocations();
        Task<Location> GetLocationById(string locationId);
        Task<Location> GetLocationByIdAsync(string locationId);
        Task<List<Location>> GetLocationsByWarehouseId(string warehouseId);
        void Create(Location location);
        void Delete(Location location);
        void Update(Location location);
    }
}

