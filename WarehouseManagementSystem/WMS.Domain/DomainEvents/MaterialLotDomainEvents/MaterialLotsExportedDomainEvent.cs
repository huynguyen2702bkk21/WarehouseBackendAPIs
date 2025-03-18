namespace WMS.Domain.DomainEvents.MaterialLotDomainEvents
{
    public class MaterialLotsExportedDomainEvent : INotification
    {
        public InventoryIssue InventoryIssue { get; set; }
        public List<MaterialLot> MaterialLots { get; set; }

        public MaterialLotsExportedDomainEvent(InventoryIssue inventoryIssue, List<MaterialLot> materialLots)
        {
            InventoryIssue = inventoryIssue;
            MaterialLots = materialLots;
        }
    }
}
