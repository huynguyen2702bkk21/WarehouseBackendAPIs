namespace WMS.Domain.InterfaceRepositories.IInventoryIssue
{
    public interface IIssueLotRepository : IRepository<IssueLot>
    {
        Task<IEnumerable<IssueLot>> GetAllIssueLotsAsync();
        Task<IssueLot> GetIssueLotByIdAsync(string id);
    }
}
