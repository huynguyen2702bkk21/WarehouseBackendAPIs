namespace WMS.Domain.InterfaceRepositories.IInventoryIssue
{
    public interface IIssueSubLotRepository : IRepository<IssueSublot>
    {
        Task<List<IssueSublot>> GetAllAsync();
        Task<IssueSublot> GetByIdAsync(string IssueSubLotId);
    }
}
