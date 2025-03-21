namespace WMS.Domain.InterfaceRepositories.IInventoryReceipt
{
    public interface IInventoryReceiptEntryRepository : IRepository<InventoryReceiptEntry>
    {
        Task<List<InventoryReceiptEntry>> GetAllAsync();
        Task<InventoryReceiptEntry> GetById(string inventoryReceiptEntryId);


    }
}
