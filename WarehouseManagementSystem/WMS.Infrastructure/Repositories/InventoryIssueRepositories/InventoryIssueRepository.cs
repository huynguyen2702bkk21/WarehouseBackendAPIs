namespace WMS.Infrastructure.Repositories.InventoryIssueRepositories
{
    public class InventoryIssueRepository : BaseRepository, IInventoryIssueRepository
    {
        public InventoryIssueRepository(WMSDbContext context) : base(context)
        {
        }

    }
}
