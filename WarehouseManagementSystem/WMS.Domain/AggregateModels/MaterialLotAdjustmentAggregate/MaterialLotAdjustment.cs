namespace WMS.Domain.AggregateModels.MaterialLotAdjustmentAggregate
{
    public class MaterialLotAdjustment : Entity, IAggregateRoot 
    {
        public string materialLotAdjustmentId { get; set; }

        public string lotNumber { get; set; }
        public MaterialLot materialLot { get; set; }

        public string warehouseId { get; set; }
        public Warehouse warehouse { get; set; }

        public string employeeId { get; set; }
        public Employee adjustedBy { get; set; }

        public DateTime adjustmentDate { get; set; }
        public double previousQuantity { get; set; }
        public double adjustedQuantity { get; set; }
        public AdjustmentReason reason { get; set; }
        public AdjustmentStatus status { get; set; }
        public string note { get; set; }
    }
}
