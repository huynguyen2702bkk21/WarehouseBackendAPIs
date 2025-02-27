
namespace WMS.Infrastructure.Repositories.PartyRepositories
{
    public class SupplierRepository : BaseRepository, ISupplierRepository
    {
        public SupplierRepository(WMSDbContext context) : base(context)
        {
        }

        public async Task<List<Supplier>> GetAllAsync()
        {
            return await _context.Suppliers.ToListAsync();

        }

        public async Task<Supplier> GetByIdAsync(string id)
        {
            return await _context.Suppliers.FirstOrDefaultAsync(s => s.supplierId == id);           
        }

        public void Create(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
        }

        public void Delete(Supplier supplier)
        {
            _context.Suppliers.Remove(supplier);
        }

        public void Update(Supplier supplier)
        {
            
            _context.Suppliers.Update(supplier);
        }
    }
}
