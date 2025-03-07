
namespace WMS.Infrastructure.Repositories.MaterialRepositories
{
    public class MaterialLotPropertyRepository : BaseRepository, IMaterialLotPropertyRepository
    {
        public MaterialLotPropertyRepository(WMSDbContext context) : base(context)
        {
        }

        public void Create(MaterialLotProperty materialLotProperty)
        {
            _context.MaterialLotProperties.Add(materialLotProperty);
        }

        public void Delete(MaterialLotProperty materialLotProperty)
        {
            _context.MaterialLotProperties.Remove(materialLotProperty);
        }

        public Task<List<MaterialLotProperty>> GetAllAsync()
        {
            return _context.MaterialLotProperties.ToListAsync();
        }

        public Task<MaterialLotProperty> GetMaterialLotPropertyById(string id)
        {
            return _context.MaterialLotProperties.FirstOrDefaultAsync(x => x.propertyId == id);
        }
    }
}
