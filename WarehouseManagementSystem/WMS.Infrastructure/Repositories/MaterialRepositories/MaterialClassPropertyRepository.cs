
namespace WMS.Infrastructure.Repositories.MaterialRepositories
{
    public class MaterialClassPropertyRepository : BaseRepository, IMaterialClassPropertyRepository
    {
        public MaterialClassPropertyRepository(WMSDbContext context) : base(context)
        {
        }

        public void Create(MaterialClassProperty materialClassProperty)
        {
            _context.MaterialClassProperties.Add(materialClassProperty);
        }

        public void Delete(MaterialClassProperty materialClassProperty)
        {
            _context.MaterialClassProperties.Remove(materialClassProperty);
        }

        public Task<List<MaterialClassProperty>> GetAllAsync()
        {
            return _context.MaterialClassProperties.ToListAsync();
        }

        public Task<MaterialClassProperty> GetByIdAsync(string id)
        {
            return _context.MaterialClassProperties.FirstOrDefaultAsync(x => x.propertyId== id);
        }

        public void Update(MaterialClassProperty materialClassProperty)
        {
            _context.MaterialClassProperties.Update(materialClassProperty);
        }
    }
}
