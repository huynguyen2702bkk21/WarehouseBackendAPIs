namespace WMS.Infrastructure.Repositories.MaterialRepositories
{
    public class MaterialRepository : BaseRepository, IMaterialRepository
    {
        public MaterialRepository(WMSDbContext context) : base(context)
        {
        }
    }
}
