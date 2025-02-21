namespace WMS.Domain.AggregateModels.InventoryReceiptAggregate
{
    public class ReceiptSublot : Entity, IAggregateRoot
    {
        public string receiptSublotId { get; set; }
        public double importedQuantity { get; set; }

        public string sublotId { get; set; }
        public MaterialSubLot sublot { get; set; }
        public string receiptLotId { get; set; }
    }
}
