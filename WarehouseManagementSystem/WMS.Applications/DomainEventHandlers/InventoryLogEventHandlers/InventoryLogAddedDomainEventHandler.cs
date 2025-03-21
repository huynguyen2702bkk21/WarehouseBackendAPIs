namespace WMS.Application.DomainEventHandlers.InventoryLogEventHandlers
{
    public class InventoryLogAddedDomainEventHandler : INotificationHandler<InventoryLogAddedDomainEvent>
    {
        private readonly IInventoryLogRepository _inventoryLogRepository;

        public InventoryLogAddedDomainEventHandler(IInventoryLogRepository inventoryLogRepository)
        {
            _inventoryLogRepository = inventoryLogRepository;
        }

        public async Task Handle(InventoryLogAddedDomainEvent notification, CancellationToken cancellationToken)
        {

            var newChangedQuantity = notification.ChangedQuantity;

            if (notification.TransactionType == TransactionType.Issue)
            {
                newChangedQuantity = -notification.ChangedQuantity;
            }

            var newInventoryLog = new InventoryLog(inventoryLogId: notification.InventoryLogId,
                                                   transactionType: notification.TransactionType,
                                                   transactionDate: notification.TransactionDate,
                                                   previousQuantity: notification.PreviousQuantity,
                                                   changedQuantity: newChangedQuantity,
                                                   afterQuantity: notification.AfterQuantity,
                                                   note: notification.Note,
                                                   lotNumber: notification.LotNumber,
                                                   warehouseId: notification.WarehouseId);

            _inventoryLogRepository.Create(newInventoryLog);

            await Task.CompletedTask;

        }

    }
}
