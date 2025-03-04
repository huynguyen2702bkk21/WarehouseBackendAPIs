namespace WMS.Application.Queries.InventoryReceiptQueries.ReceiptSubLots
{
    public class GetReceiptSubLotByIdQuery : IRequest<ReceiptSubLotDTO>
    {
        public string ReceiptSublotId { get; set; }

        public GetReceiptSubLotByIdQuery(string receiptSublotId)
        {
            ReceiptSublotId = receiptSublotId;
        }
    }
}
