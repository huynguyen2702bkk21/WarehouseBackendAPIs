namespace WMS.Domain.InterfaceRepositories.IInventoryReceipt
{
    public interface IReceiptSubLotRepository : IRepository<ReceiptSublot>
    {
        Task<List<ReceiptSublot>> GetAllAsync();
        Task<ReceiptSublot> GetByIdAsync(string receiptSublotId);
        Task<List<ReceiptSublot>> GetSublotsByLotId(string lotId);
    }
}
