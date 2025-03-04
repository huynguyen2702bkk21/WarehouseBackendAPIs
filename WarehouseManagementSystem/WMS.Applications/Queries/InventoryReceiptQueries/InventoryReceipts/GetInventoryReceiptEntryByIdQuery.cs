namespace WMS.Application.Queries.InventoryReceiptQueries.InventoryReceipts
{
    public class GetInventoryReceiptEntryByIdQuery : IRequest<InventoryReceiptEntryDTO>
    {
        public string InventoryReceiptEntryId { get; set; }

        public GetInventoryReceiptEntryByIdQuery(string inventoryReceiptEntryId)
        {
            InventoryReceiptEntryId = inventoryReceiptEntryId;
        }
    }
}
