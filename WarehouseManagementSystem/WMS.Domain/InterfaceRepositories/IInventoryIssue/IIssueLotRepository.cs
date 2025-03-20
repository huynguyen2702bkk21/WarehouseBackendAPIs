namespace WMS.Domain.InterfaceRepositories.IInventoryIssue
{
    public interface IIssueLotRepository : IRepository<IssueLot>
    {
        Task<List<IssueLot>> GetAllIssueLotsAsync();
        Task<IssueLot> GetIssueLotByIdAsync(string id);
    }
}
