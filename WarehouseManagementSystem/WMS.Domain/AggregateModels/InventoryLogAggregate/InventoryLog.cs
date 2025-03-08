namespace WMS.Domain.AggregateModels.InventoryLogAggregate
{
    public class InventoryLog : Entity, IAggregateRoot
    {
        [Key]
        public string inventoryLogId { get; set; }
        public TransactionType transactionType { get; set; }
        public DateTime transactionDate { get; set; }
        public double previousQuantity { get; set; }
        public double changedQuantity { get; set; }
        public double afterQuantity { get; set; }
        public string note { get; set; }

        [ForeignKey("lotNumber")]
        public string lotNumber { get; set; }
        public MaterialLot materialLot { get; set; }

        [ForeignKey("warehouseId")]
        public string warehouseId { get; set; }
        public Warehouse warehouse { get; set; }

        public InventoryLog(string inventoryLogId, TransactionType transactionType, DateTime transactionDate, double previousQuantity, double changedQuantity, double afterQuantity, string note, string lotNumber, string warehouseId)
        {
            this.inventoryLogId = inventoryLogId;
            this.transactionType = transactionType;
            this.transactionDate = transactionDate;
            this.previousQuantity = previousQuantity;
            this.changedQuantity = changedQuantity;
            this.afterQuantity = afterQuantity;
            this.note = note;
            this.lotNumber = lotNumber;
            this.warehouseId = warehouseId;
        }
    }
}
