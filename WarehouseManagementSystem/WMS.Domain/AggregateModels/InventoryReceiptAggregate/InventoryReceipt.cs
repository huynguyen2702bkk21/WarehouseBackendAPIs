using WMS.Domain.DomainEvents.InventoryLogEvents;
using WMS.Domain.DomainEvents.MaterialLotDomainEvents;

namespace WMS.Domain.AggregateModels.InventoryReceiptAggregate
{
    public class InventoryReceipt : Entity, IAggregateRoot
    {
        [Key]
        public string inventoryReceiptId { get; set; }
        
        public DateTime receiptDate { get; set; }
        public ReceiptStatus receiptStatus { get; set; }

        [ForeignKey("supplierId")]
        public string supplierId { get; set; }
        public Supplier supplier { get; set; }

        [ForeignKey("personId")]
        public string personId { get; set; }
        public Person receivedBy { get; set; }

        [ForeignKey("warehouseId")]
        public string warehouseId { get; set; }
        public Warehouse warehouse { get; set; }

        public List<InventoryReceiptEntry> entries { get; set; }

        public InventoryReceipt(string inventoryReceiptId, DateTime receiptDate, ReceiptStatus receiptStatus, string supplierId, string personId, string warehouseId)
        {
            this.inventoryReceiptId = inventoryReceiptId;
            this.receiptDate = receiptDate;
            this.receiptStatus = receiptStatus;
            this.supplierId = supplierId;
            this.personId = personId;
            this.warehouseId = warehouseId;
            this.entries = new List<InventoryReceiptEntry>();
        }

        public void AddEntry(InventoryReceiptEntry entry)
        {
            entries.Add(entry);
        }

        public void Update(string supplierId, string personId, string warehouseId)
        {
            this.supplierId = supplierId;
            this.personId = personId;
            this.warehouseId = warehouseId;
        }

        public void Confirm(List<MaterialLot> materialLots, InventoryReceipt inventoryReceipt)
        {
            AddDomainEvent(new MaterialLotsImportedDomainEvent(materialLots));

            foreach(var materialLot in materialLots)
            {

                AddDomainEvent(new InventoryLogAddedDomainEvent(transactionType: TransactionType.Receipt,
                                                                transactionDate: GetVietnamTime(),
                                                                previousQuantity: 0,
                                                                changedQuantity: materialLot.exisitingQuantity,
                                                                afterQuantity: materialLot.exisitingQuantity,
                                                                note: "",
                                                                lotNumber: materialLot.lotNumber,
                                                                warehouseId: inventoryReceipt.warehouseId));
            }

        }

        private static DateTime GetVietnamTime()
        {
            return TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time"));
        }


    }
}
