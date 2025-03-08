namespace WMS.Domain.DomainEvents.InventoryReceiptEvents
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
