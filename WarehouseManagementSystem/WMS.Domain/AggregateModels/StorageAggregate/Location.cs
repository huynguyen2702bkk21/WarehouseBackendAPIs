using System.ComponentModel.DataAnnotations.Schema;

namespace WMS.Domain.AggregateModels.StorageAggregate
{
    public class Location : Entity, IAggregateRoot
    {
        [Key]
        public string locationId { get; set; }

        public List<MaterialSubLot> materialSubLots { get; set; }
        public List<ReceiptSublot> receiptSublots { get; set; }
        public List<IssueSublot> issueSublots { get; set; }

        [ForeignKey("warehouseId")]
        public string warehouseId { get; set; }
        public Warehouse warehouse { get; set; }
    }
}
