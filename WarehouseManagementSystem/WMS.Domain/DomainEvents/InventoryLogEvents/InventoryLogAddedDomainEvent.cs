namespace WMS.Domain.DomainEvents.InventoryLogEvents
{
    public  class InventoryLogAddedDomainEvent : INotification
    {
        public string InventoryLogId { get; set; }
        public TransactionType TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }
        public double PreviousQuantity { get; set; }
        public double ChangedQuantity { get; set; }
        public double AfterQuantity { get; set; }
        public string Note { get; set; }
        public string LotNumber { get; set; }
        public string WarehouseId { get; set; }

        public InventoryLogAddedDomainEvent(TransactionType transactionType, DateTime transactionDate, double previousQuantity, double changedQuantity, double afterQuantity, string note, string lotNumber, string warehouseId)
        {
            InventoryLogId = Guid.NewGuid().ToString();
            TransactionType = transactionType;
            TransactionDate = transactionDate;
            PreviousQuantity = previousQuantity;
            ChangedQuantity = changedQuantity;
            AfterQuantity = afterQuantity;
            Note = note;
            LotNumber = lotNumber;
            WarehouseId = warehouseId;
        }
    }
}
