namespace WMS.Domain.AggregateModels.MaterialAggregate
{
    public class MaterialSubLot : Entity, IAggregateRoot
    {
        [Key]
        public string subLotId { get; set; }
        public LotStatus subLotStatus { get; set; }
        public double existingQuality { get; set; }
        public UnitOfMeasure unitOfMeasure { get; set; }

        [ForeignKey("locationId")]
        public string locationId { get; set; }
        public Location  location{ get; set; }

        [ForeignKey("lotNumber")]
        public string lotNumber { get; set; }
        public MaterialLot materialLot { get; set; }

        public List<IssueSublot> issueSublots { get; set; }

        public MaterialSubLot(string subLotId, LotStatus subLotStatus, double existingQuality, UnitOfMeasure unitOfMeasure, string locationId, string lotNumber)
        {
            this.subLotId = subLotId;
            this.subLotStatus = subLotStatus;
            this.existingQuality = existingQuality;
            this.unitOfMeasure = unitOfMeasure;
            this.locationId = locationId;
            this.lotNumber = lotNumber;
        }

        public void Update(LotStatus subLotStatus, double existingQuality, UnitOfMeasure unitOfMeasure, string locationId, string lotNumber)
        {
            this.subLotStatus = subLotStatus;
            this.existingQuality = existingQuality;
            this.unitOfMeasure = unitOfMeasure;
            this.locationId = locationId;
            this.lotNumber = lotNumber;
        }

        public void Export(double requestedQuantity)
        {
            if (requestedQuantity > existingQuality)
            {
                throw new Exception("Requested quantity is greater than existing quality");
            }

            existingQuality = existingQuality - requestedQuantity;
        }


    }
}
