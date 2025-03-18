namespace WMS.Application.DomainEventHandlers.MaterialLotDomainEventHandlers
{
    public class MaterialLotsExportedDomainEventHandler : INotificationHandler<MaterialLotsExportedDomainEvent>
    {
        private readonly IMaterialLotRepository _materialLotRepository;
        private readonly IMaterialSubLotRepository _materialSubLotRepository;
        public MaterialLotsExportedDomainEventHandler(IMaterialLotRepository materialLotRepository, IMaterialSubLotRepository materialSubLotRepository)
        {
            _materialLotRepository = materialLotRepository;
            _materialSubLotRepository = materialSubLotRepository;
        }

        public async Task Handle(MaterialLotsExportedDomainEvent notification, CancellationToken cancellationToken)
        {
            foreach (var entry in notification.InventoryIssue.entries)
            {
                var materialSublots = await _materialSubLotRepository.GetMaterialSubLotsByLotNumber(entry.issueLot.materialLotId);
                var totalQualitySublotBeFore = materialSublots.Sum(x => x.existingQuality);

                foreach (var subLot in entry.issueLot.issueSublots)
                {
                    var materialSubLot = await _materialSubLotRepository.GetByIdAsync(subLot.sublotId);
                    if (materialSubLot == null)
                    {
                        throw new EntityNotFoundException(nameof(MaterialSubLot), subLot.sublotId);
                    }

                    if (subLot.requestedQuantity > materialSubLot.existingQuality)
                    {
                        throw new Exception($"Requested quantity ({subLot.requestedQuantity}) exceeds available quantity ({materialSubLot.existingQuality}) for sublot {subLot.sublotId}");
                    }

                    materialSubLot.Export(subLot.requestedQuantity);

                    if (materialSubLot.existingQuality == 0)
                    {
                        _materialSubLotRepository.Delete(materialSubLot);
                    }

                }

                var totalQuantityShipped = entry.issueLot.issueSublots.Sum(x => x.requestedQuantity);
                var totalQualitySublotAfter = totalQualitySublotBeFore - totalQuantityShipped;  // This also mean LotQuantity

                var materialLot = await _materialLotRepository.GetMaterialLotById(entry.issueLot.materialLotId);
                if (materialLot == null)
                {
                    throw new EntityNotFoundException(nameof(MaterialLot), entry.issueLot.materialLotId);
                }

                if (entry.issueLot.requestedQuantity > materialLot.exisitingQuantity)
                {
                    throw new Exception($"Requested quantity ({entry.issueLot.requestedQuantity}) exceeds available quantity ({materialLot.exisitingQuantity}) for lot {entry.issueLot.materialLotId}");
                }

                materialLot.Export(entry.issueLot.requestedQuantity);

                if (materialLot.exisitingQuantity != totalQualitySublotAfter)
                {
                    throw new Exception("The quantity of sublots does not match the quantity of the lot");
                }

                if (materialLot.exisitingQuantity == 0)
                {
                    _materialLotRepository.Delete(materialLot);
                }


            }

            await Task.CompletedTask;
        }
    }
}
