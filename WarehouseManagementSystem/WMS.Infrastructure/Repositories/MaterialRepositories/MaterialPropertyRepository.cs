namespace WMS.Infrastructure.Repositories.MaterialRepositories
{
    public class MaterialPropertyRepository : BaseRepository, IMaterialPropertyRepository
    {
        public MaterialPropertyRepository(WMSDbContext context) : base(context)
        {
        }
    }
}
