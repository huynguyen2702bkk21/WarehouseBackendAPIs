﻿using WMS.Domain.InterfaceRepositories.IStorage;

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

        public Task<Warehouse> GetWarehouseById(string warehouseId)
        {
            return _context.Warehouses.FirstOrDefaultAsync(x => x.warehouseId == warehouseId);
        }

        public void Update(Warehouse warehouse)
        {
            _context.Warehouses.Update(warehouse);
        }
    }
}
