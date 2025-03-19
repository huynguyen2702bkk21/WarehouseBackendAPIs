using WMS.Domain.InterfaceRepositories.IStorage;

namespace WMS.Infrastructure.Repositories.StorageRepositories
{
    public class LocationRepository : BaseRepository, ILocationRepository
    {
        public LocationRepository(WMSDbContext context) : base(context)
        {
        }

        public void Create(Location location)
        {
            _context.Locations.Add(location);

        }

        public void Delete(Location location)
        {
            _context.Locations.Remove(location);
        }

        public async Task<List<Location>> GetAllLocations()
        {
            return await _context.Locations.ToListAsync();  
        }

        public async Task<Location> GetLocationById(string locationId)
        {
            return await _context.Locations.FirstOrDefaultAsync(x => x.locationId== locationId);
        }

        public async Task<Location> GetLocationByIdAsync(string locationId)
        {
            var location = await _context.Locations
                .Include(x => x.materialSubLots)
                .FirstOrDefaultAsync(x => x.locationId == locationId);

            return location;
        }

        public async Task<List<Location>> GetLocationsByWarehouseId(string warehouseId)
        {
            return await _context.Locations.Where(x => x.warehouseId == warehouseId).ToListAsync();
        }

        public void Update(Location location)
        {
            _context.Locations.Update(location);
        }
    }
}
