namespace WMS.Domain.AggregateModels.MaterialLotAdjustmentAggregate
{
    public class MaterialLotAdjustment : Entity, IAggregateRoot 
    {
        [Key]
        public string materialLotAdjustmentId { get; set; }

        public DateTime adjustmentDate { get; set; }
        public double previousQuantity { get; set; }
        public double adjustedQuantity { get; set; }
        public AdjustmentReason reason { get; set; }
        public AdjustmentStatus status { get; set; }
        public string note { get; set; }

        [ForeignKey("lotNumber")]
        public string lotNumber { get; set; }
        public MaterialLot materialLot { get; set; }

        [ForeignKey("warehouseId")]
        public string warehouseId { get; set; }
        public Warehouse warehouse { get; set; }

        [ForeignKey("employeeId")]
        public string employeeId { get; set; }
        public Employee adjustedBy { get; set; }

    }
}
