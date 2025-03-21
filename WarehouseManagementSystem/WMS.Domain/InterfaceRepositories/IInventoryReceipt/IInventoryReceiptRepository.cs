namespace WMS.Domain.InterfaceRepositories.IInventoryReceipt
{
    public interface IInventoryReceiptRepository : IRepository<InventoryReceipt>
    {
        Task<List<InventoryReceipt>> GetAllAsync();
        Task<InventoryReceipt> GetByIdAsync(string inventoryReceiptId);
        Task<List<InventoryReceipt>> GetInventoryReceiptByEntryId(List<string> entryId);
        void Create(InventoryReceipt inventoryReceipt);
        void Delete(InventoryReceipt inventoryReceipt);
    }
}
