namespace WMS.Infrastructure.Repositories.MaterialRepositories
{
    public class MaterialLotRepository : BaseRepository, IMaterialLotRepository
    {
        public MaterialLotRepository(WMSDbContext context) : base(context)
        {
        }
    }
}
