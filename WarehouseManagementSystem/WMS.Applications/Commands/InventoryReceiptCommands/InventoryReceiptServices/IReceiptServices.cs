namespace WMS.Application.Commands.InventoryReceiptCommands.InventoryReceiptServices
{
    public interface IReceiptServices
    {
        Task<InventoryReceipt> CreateNewInventoryReceipt(CreateInventoryReceiptCommand request);
        Task AddToMaterialLot(InventoryReceipt newInventoryReceipt);
        Task<InventoryReceiptEntry> CreateEntry(CreateInventoryReceiptEntryCommand request);
        Task UpdateReceiptEntries(UpdateInventoryReceiptEntriesCommand request);
        Task AddReceiptLotToMaterialLot(InventoryReceipt newInventoryReceipt);


    }
}
