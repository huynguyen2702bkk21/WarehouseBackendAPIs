namespace WMS.Infrastructure.Repositories.InventoryIssueRepositories
{
    public class InventoryIssueEntryRepository : BaseRepository, IInventoryIssueEntryRepository
    {
        public InventoryIssueEntryRepository(WMSDbContext context) : base(context)
        {
        }


    }
}
