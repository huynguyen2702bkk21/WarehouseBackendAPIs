using System.ComponentModel.DataAnnotations.Schema;

namespace WMS.Application.DTOs.InventoryTrackingDTOs
{
    public class InventoryLogReceiptDTO
    {
        public string InventoryLogId { get; set; }
        public TransactionType TransactionType { get; set; }
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


    }
}
