namespace WMS.Infrastructure.Repositories.MaterialRepositories
{
    public class MaterialSubLotRepository : BaseRepository, IMaterialSubLotRepository
    {
        public MaterialSubLotRepository(WMSDbContext context) : base(context)
        {
        }
    }
}
