namespace WMS.Application.Queries.InventoryReceiptQueries.ReceiptLots
{
    public class GetReceiptLotByIdQuery : IRequest<ReceiptLotDTO>
    {
        public string ReceiptLotId { get; set; }

        public GetReceiptLotByIdQuery(string receiptLotId)
        {
            ReceiptLotId = receiptLotId;
        }
    }
}
