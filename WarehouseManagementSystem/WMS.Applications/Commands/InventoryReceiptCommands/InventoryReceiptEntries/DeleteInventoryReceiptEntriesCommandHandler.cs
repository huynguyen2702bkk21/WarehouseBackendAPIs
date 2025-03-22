namespace WMS.Application.Commands.InventoryReceiptCommands.InventoryReceiptEntries
{
    public class DeleteInventoryReceiptEntriesCommandHandler : IRequestHandler<DeleteInventoryReceiptEntriesCommand, bool>
    {
        private readonly IInventoryReceiptRepository _inventoryReceiptRepository;
        private readonly IInventoryReceiptEntryRepository _inventoryReceiptEntryRepository;

        public DeleteInventoryReceiptEntriesCommandHandler(IInventoryReceiptRepository inventoryReceiptRepository, IInventoryReceiptEntryRepository inventoryReceiptEntryRepository)
        {
            _inventoryReceiptRepository = inventoryReceiptRepository;
            _inventoryReceiptEntryRepository = inventoryReceiptEntryRepository;
        }

        public async Task<bool> Handle(DeleteInventoryReceiptEntriesCommand request, CancellationToken cancellationToken)
        {
            var inventoryReceipts = await _inventoryReceiptRepository.GetInventoryReceiptsByEntryIds(request.entryIds);
            if (inventoryReceipts.Count == 0)
            {
                throw new EntityNotFoundException("The InventoryReceipts Not Found");
            }

            foreach (var inventoryReceipt in inventoryReceipts)
            {
                if (inventoryReceipt.receiptStatus == ReceiptStatus.Completed)
                {
                    continue;
                }

                var entriesToRemove = inventoryReceipt.entries
                    .Where(x => request.entryIds.Contains(x.inventoryReceiptEntryId))
                    .ToList();

                if (entriesToRemove.Count == 0)
                {
                    return await _inventoryReceiptRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
                }

                foreach (var entry in entriesToRemove)
                {
                    inventoryReceipt.entries.Remove(entry);
                }
            }

            return await _inventoryReceiptRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }


    }
}
