
namespace WMS.Infrastructure.Repositories.MaterialRepositories
{
    public class MaterialCLassRepository : BaseRepository, IMaterialClassRepository
    {
        public MaterialCLassRepository(WMSDbContext context) : base(context)
        {
        }

        public async Task<List<MaterialClass>> GetAllAsync()
        {
            return await _context.MaterialClasses.ToListAsync();
        }
    }
}
