using WMS.Domain.InterfaceRepositories.IStorage;

namespace WMS.Infrastructure.Repositories.StogareRepositories
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
            var location = await _context.Locations.FirstOrDefaultAsync(x => x.locationId == locationId);
            if(location == null)
            {
                throw new Exception($"Location With Id: {locationId} not Found");
            }

            var materialSubLots = await _context.MaterialSubLots.Where(x => x.locationId == locationId).ToListAsync();
            if(materialSubLots == null)
            {
                materialSubLots = new List<MaterialSubLot>();
            }

            location.materialSubLots = materialSubLots;

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
