using DocumentFormat.OpenXml.Office2010.Excel;
using WMS.Domain.InterfaceRepositories.IStorage;

namespace WMS.Infrastructure.Repositories.StogareRepositories
{
    public class WarehouseRepository : BaseRepository, IWarehouseRepository
    {
        public WarehouseRepository(WMSDbContext context) : base(context)
        {
        }

        public void Create(Warehouse warehouse)
        {
            _context.Warehouses.Add(warehouse);
        }

        public void Delete(Warehouse warehouse)
        {
            _context.Warehouses.Remove(warehouse);
        }

        public async Task<List<Warehouse>> GetAllWarehouses()
        {
            return await _context.Warehouses.ToListAsync();
        }

        public async Task<Warehouse> GetWarehouseById(string warehouseId)
        {
            return await _context.Warehouses.FirstOrDefaultAsync(x => x.warehouseId == warehouseId);
        }

        public async Task<Warehouse> GetWarehouseByIdAsync(string id)
        {
            var warehouse = await _context.Warehouses
                .Include(x => x.locations)
                .FirstOrDefaultAsync(x => x.warehouseId== id);

            return warehouse;
        }

        public void Update(Warehouse warehouse)
        {
            _context.Warehouses.Update(warehouse);
        }
    }
}
