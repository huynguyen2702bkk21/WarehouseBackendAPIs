
namespace WMS.Infrastructure.Repositories.MaterialRepositories
{
    public class MaterialClassPropertyRepository : BaseRepository, IMaterialClassPropertyRepository
    {
        public MaterialClassPropertyRepository(WMSDbContext context) : base(context)
        {
        }

        public void AddAsync(MaterialClassProperty materialClassProperty)
        {
            _context.MaterialClassProperties.Add(materialClassProperty);
        }

        public Task<List<MaterialClassProperty>> GetAllAsync()
        {
            return _context.MaterialClassProperties.ToListAsync();
        }

        public Task<MaterialClassProperty> GetByIdAsync(string id)
        {
            return _context.MaterialClassProperties.FirstOrDefaultAsync(x => x.propertyId== id);
        }
    }
}
