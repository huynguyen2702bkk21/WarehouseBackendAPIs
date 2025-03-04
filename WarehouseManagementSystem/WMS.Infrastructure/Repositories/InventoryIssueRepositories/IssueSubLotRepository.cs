namespace WMS.Infrastructure.Repositories.InventoryIssueRepositories
{
    public class IssueSubLotRepository : BaseRepository, IIssueSubLotRepository
    {
        public IssueSubLotRepository(WMSDbContext context) : base(context)
        {
        }

    }
}
