namespace WMS.Domain.InterfaceRepositories.IInventoryReceipt
{
    public interface IReceiptLotRepository : IRepository<ReceiptLot>
    {
        Task<List<ReceiptLot>> GetAllAsync();
        Task<ReceiptLot> GetById(string Id);
        Task<ReceiptLot> GetByIdAsnc(string lotNumber);
    }
}
