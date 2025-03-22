namespace WMS.Application.Commands.InventoryIssueCommands.InventoryIssueEntries
{
    public class DeleteInventoryIssueEntriesCommandHandler : IRequestHandler<DeleteInventoryIssueEntriesCommand, bool>
    {
        private readonly IInventoryIssueEntryRepository _inventoryIssueEntryRepository;

        public DeleteInventoryIssueEntriesCommandHandler(IInventoryIssueEntryRepository inventoryIssueEntryRepository)
        {
            _inventoryIssueEntryRepository = inventoryIssueEntryRepository;
        }

        public async Task<bool> Handle(DeleteInventoryIssueEntriesCommand request, CancellationToken cancellationToken)
        {

            var inventoryIssues = await _inventoryIssueEntryRepository.GetInventoryIssuesByEntryIds(request.EntryIds);
            if (inventoryIssues.Count == 0)
            {
                throw new EntityNotFoundException("The InventoryReceipts Not Found");
            }

            foreach (var inventoryIssue in inventoryIssues)
            {
                if (inventoryIssue.issueStatus == IssueStatus.Completed)
                {
                    continue;
                }

                var entriesToRemove = inventoryIssue.entries
                    .Where(x => request.EntryIds.Contains(x.inventoryIssueEntryId))
                    .ToList();

                if (entriesToRemove.Count == 0)
                {
                    return await _inventoryIssueEntryRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
                }

                foreach (var entry in entriesToRemove)
                {
                    inventoryIssue.entries.Remove(entry);
                }
            }

            return await _inventoryIssueEntryRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        }


    }
}
