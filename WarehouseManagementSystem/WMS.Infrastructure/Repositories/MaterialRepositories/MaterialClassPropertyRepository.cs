
namespace WMS.Infrastructure.Repositories.MaterialRepositories
{
    public class MaterialClassPropertyRepository : BaseRepository, IMaterialClassPropertyRepository
    {
        public MaterialClassPropertyRepository(WMSDbContext context) : base(context)
        {
        }

        public Task<List<MaterialClassProperty>> GetAllAsync()
        {
            return _context.MaterialClassProperties.ToListAsync();
        }
    }
}
