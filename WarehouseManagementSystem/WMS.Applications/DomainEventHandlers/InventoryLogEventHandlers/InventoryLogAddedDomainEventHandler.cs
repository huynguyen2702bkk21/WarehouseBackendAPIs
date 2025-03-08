using WMS.Domain.AggregateModels.InventoryLogAggregate;
using WMS.Domain.DomainEvents.InventoryLogEvents;
using WMS.Domain.InterfaceRepositories.IInventoryLog;

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
            var inventoryLog = await _inventoryLogRepository.GetInventoryLogByLotNumber(notification.LotNumber);
            if(inventoryLog != null)
            {
                throw new DuplicateRecordException(nameof(InventoryLog),notification.LotNumber);
            }

            var newInventoryLog = new InventoryLog(inventoryLogId: notification.InventoryLogId,
                                                   transactionType: notification.TransactionType,
                                                   transactionDate: notification.TransactionDate,
                                                   previousQuantity: notification.PreviousQuantity,
                                                   changedQuantity: notification.ChangedQuantity,
                                                   afterQuantity: notification.AfterQuantity,
                                                   note: notification.Note,
                                                   lotNumber: notification.LotNumber,
                                                   warehouseId: notification.WarehouseId);

            _inventoryLogRepository.Create(newInventoryLog);

        }

    }
}
