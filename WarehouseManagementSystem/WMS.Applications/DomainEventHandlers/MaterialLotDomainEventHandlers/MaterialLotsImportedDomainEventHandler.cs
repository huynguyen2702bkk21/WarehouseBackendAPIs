namespace WMS.Application.DomainEventHandlers.InventoryReceiptEventHandlers
{
    public class MaterialLotsImportedDomainEventHandler : INotificationHandler<MaterialLotsImportedDomainEvent>
    {
        private readonly IMaterialLotRepository _materialLotRepository;
        public MaterialLotsImportedDomainEventHandler(IMaterialLotRepository materialLotRepository)
        {
            _materialLotRepository = materialLotRepository;
        }

        public async Task Handle(MaterialLotsImportedDomainEvent notification, CancellationToken cancellationToken)
        {
            foreach (var materialLot in notification.MaterialLots)
            {
                var materialLotExists = await _materialLotRepository.GetMaterialLotById(materialLot.lotNumber);
                if (materialLotExists != null)
                {
                    throw new DuplicateRecordException(nameof(MaterialLot), materialLot.lotNumber);
                }
                _materialLotRepository.Create(materialLot);
            }

            await Task.CompletedTask;
        }

    }
}
