namespace WMS.Domain.InterfaceRepositories.IInventoryIssue
{
    public interface IIssueSubLotRepository : IRepository<IssueSublot>
    {
        Task<IEnumerable<IssueSublot>> GetAllAsync();
        Task<IssueSublot> GetByIdAsync(string IssueSubLotId);
    }
}
