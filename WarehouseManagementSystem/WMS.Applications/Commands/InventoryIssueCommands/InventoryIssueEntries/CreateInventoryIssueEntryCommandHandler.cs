namespace WMS.Application.Commands.InventoryIssueCommands.InventoryIssueEntries
{
    public class CreateInventoryIssueEntryCommandHandler : IRequestHandler<CreateInventoryIssueEntryCommand,bool>
    {
        private readonly IInventoryIssueEntryRepository _inventoryIssueEntryRepository;
        private readonly IInventoryIssueRepository _inventoryIssueRepository;
        private readonly IIssueServices _issueServices;

        public CreateInventoryIssueEntryCommandHandler(IInventoryIssueEntryRepository inventoryIssueEntryRepository, IInventoryIssueRepository inventoryIssueRepository, IIssueServices issueServices)
        {
            _inventoryIssueEntryRepository = inventoryIssueEntryRepository;
            _inventoryIssueRepository = inventoryIssueRepository;
            _issueServices = issueServices;
        }

        public async Task<bool> Handle(CreateInventoryIssueEntryCommand request, CancellationToken cancellationToken)
        {
            var inventoryIssue = await _inventoryIssueRepository.GetByIdAsync(request.InventoryIssueId);
            if (inventoryIssue == null)
            {
                throw new EntityNotFoundException(nameof(InventoryIssue), request.InventoryIssueId);
            }

            if (inventoryIssue.issueStatus == IssueStatus.Completed)
            {
                throw new Exception("The Issue has been Done");
            }

            var Entry = await _inventoryIssueEntryRepository.GetInventoryIssueEntryByIdAsync(request.InventoryIssueEntryId);
            if (Entry != null)
            {
                throw new DuplicateRecordException(nameof(InventoryIssueEntry), request.InventoryIssueEntryId);
            }

            var newEntry = await _issueServices.CreateEntry(request);

            inventoryIssue.AddEntry(newEntry);

            return await _inventoryIssueRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }


    }
}
