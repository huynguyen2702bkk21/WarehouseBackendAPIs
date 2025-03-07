namespace WMS.Application.Queries.InventoryReceiptQueries.InventoryReceiptEntries
{
    public class GetInventoryReceiptByIdQuery : IRequest<InventoryReceiptDTO>
    {
        public string InventoryReceiptId { get; set; }

        public GetInventoryReceiptByIdQuery(string inventoryReceiptId)
        {
            InventoryReceiptId = inventoryReceiptId;
        }
    }
}
