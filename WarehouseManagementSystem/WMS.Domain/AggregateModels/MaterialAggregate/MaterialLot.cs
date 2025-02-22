namespace WMS.Domain.AggregateModels.MaterialAggregate
{
    public class MaterialLot : Entity, IAggregateRoot
    {
        [Key]
        public string lotNumber { get; set; }

        public LotStatus lotStatus { get; set; }

        [ForeignKey("materialId")]
        public string materialId { get; set; }
        public Material material { get; set; }

        public double exisitingQuantity { get; set; }
        public List<MaterialLotProperty> properties { get; set; }
        public List<MaterialSubLot> subLots{ get; set; }
        public List<InventoryLog> inventoryLogs { get; set; }

    }
}
