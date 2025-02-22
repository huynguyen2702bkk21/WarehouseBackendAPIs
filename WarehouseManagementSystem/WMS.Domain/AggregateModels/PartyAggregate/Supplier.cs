using WMS.Domain.AggregateModels.InventoryReceiptAggregate;

namespace WMS.Domain.AggregateModels.PartyAggregate
{
    public class Supplier : Entity, IAggregateRoot  
    {
        [Key]
        public string supplierId { get; set; }

        public string supplierName { get; set; }
        public string address { get; set; }
        public string contactDetails { get; set; }

        public List<InventoryReceipt> inventoryReceipts { get; set; }
    }
}
