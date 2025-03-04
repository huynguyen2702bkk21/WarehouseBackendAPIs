namespace WMS.Infrastructure.Repositories.InventoryIssueRepositories
{
    public class IssueLotRepository : BaseRepository, IIssueLotRepository
    {
        public IssueLotRepository(WMSDbContext context) : base(context)
        {
        }

    }
}
