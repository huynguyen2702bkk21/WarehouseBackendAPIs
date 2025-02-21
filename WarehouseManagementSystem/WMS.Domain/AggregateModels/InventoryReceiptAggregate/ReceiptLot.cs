namespace WMS.Domain.AggregateModels.InventoryReceiptAggregate
{
    public class ReceiptLot : Entity, IAggregateRoot
    {
        public string receiptLotId { get; set; }
        public double importedQuantity { get; set; }
        public List<ReceiptSublot> receiptSublots { get; set; }

        public string materialLotId { get; set; }  
        public MaterialLot materialLot { get; set; }

        public string InventoryReceiptEntryId { get; set; } 
    }
}
