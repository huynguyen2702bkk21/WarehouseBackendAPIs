namespace WMS.Domain.DomainEvents.MaterialLotDomainEvents
{
    public class MaterialLotsImportedDomainEvent : INotification
    {
        public List<MaterialLot> MaterialLots  { get; set; }

        public MaterialLotsImportedDomainEvent(List<MaterialLot> materialLots)
        {
            MaterialLots = materialLots;
        }
    }
}
