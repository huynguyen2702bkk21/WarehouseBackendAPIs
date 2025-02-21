namespace WMS.Domain.AggregateModels.MaterialAggregate
{
    public class MaterialLot : Entity, IAggregateRoot
    {
        public string lotNumber { get; set; }
        public LotStatus lotStatus { get; set; }
        public string materialId { get; set; }
        public Material material { get; set; }
        public double exisitingQuantity { get; set; }
        public List<MaterialLotProperty> properties { get; set; }
        public List<MaterialSubLot> subLots{ get; set; }
    }
}
