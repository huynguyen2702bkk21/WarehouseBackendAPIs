using WMS.Domain.AggregateModels.StorageAggregate;

namespace WMS.Domain.AggregateModels.InventoryReceiptAggregate
{
    public class ReceiptSublot : Entity, IAggregateRoot
    {
        [Key]
        public string receiptSublotId { get; set; }
        
        public double importedQuantity { get; set; }
        public LotStatus subLotStatus { get; set; }
        public UnitOfMeasure unitOfMeasure { get; set; }

        [ForeignKey("locationId")]
        public string locationId { get; set; }
        public Location location { get; set; }

        [ForeignKey("receiptLotId")]
        public string receiptLotId { get; set; }
        public ReceiptLot receiptLot { get; set; }

        public  ReceiptSublot(string receiptSublotId, double importedQuantity, LotStatus subLotStatus, UnitOfMeasure unitOfMeasure, string locationId, string receiptLotId)
        {
            this.receiptSublotId = receiptSublotId;
            this.importedQuantity = importedQuantity;
            this.subLotStatus = subLotStatus;
            this.unitOfMeasure = unitOfMeasure;
            this.locationId = locationId;
            this.receiptLotId = receiptLotId;
        }

        public void Update(double importedQuantity, LotStatus subLotStatus, UnitOfMeasure unitOfMeasure, string locationId)
        {
            this.importedQuantity = importedQuantity;
            this.subLotStatus = subLotStatus;
            this.unitOfMeasure = unitOfMeasure;
            this.locationId = locationId;

        }


    }
}
