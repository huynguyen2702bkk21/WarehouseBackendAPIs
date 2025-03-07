namespace WMS.Domain.InterfaceRepositories.IInventoryReceipt
{
    public interface IInventoryReceiptRepository : IRepository<InventoryReceipt>
    {
        Task<List<InventoryReceipt>> GetAllAsync();
        Task<InventoryReceipt> GetByIdAsync(string inventoryReceiptId);
        void Create(InventoryReceipt inventoryReceipt);
    }
}
