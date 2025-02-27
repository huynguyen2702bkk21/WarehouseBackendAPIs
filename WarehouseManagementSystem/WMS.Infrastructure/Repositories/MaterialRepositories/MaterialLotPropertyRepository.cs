namespace WMS.Infrastructure.Repositories.MaterialRepositories
{
    public class MaterialLotPropertyRepository : BaseRepository, IMaterialLotPropertyRepository
    {
        public MaterialLotPropertyRepository(WMSDbContext context) : base(context)
        {
        }
    }
}
