namespace WMS.Application.Commands.InventoryIssueCommands.InventoryIssueEntries
{
    public class UpdateInventoryIssueEntryCommandHandler : IRequestHandler<UpdateInventoryIssueEntryCommand, bool>
    {
        private readonly IInventoryIssueRepository _inventoryIssueRepository;
        private readonly IIssueServices _issueServices;

        public UpdateInventoryIssueEntryCommandHandler(IInventoryIssueRepository inventoryIssueRepository, IIssueServices issueServices)
        {
            _inventoryIssueRepository = inventoryIssueRepository;
            _issueServices = issueServices;
        }

        public async Task<bool> Handle(UpdateInventoryIssueEntryCommand request, CancellationToken cancellationToken)
        {

            var inventoryIssue = await _inventoryIssueRepository.GetByIdAsync(request.InventoryIssueId);
            if (inventoryIssue == null)
            {
                throw new EntityNotFoundException(nameof(InventoryIssue), request.InventoryIssueId);
            }
            if (inventoryIssue.issueStatus == IssueStatus.Completed)
            {
                throw new Exception("The Issue has been saved");
            }

            await _issueServices.UpdateIssueEntries(request);

            await _issueServices.UpdateMaterialLot(inventoryIssue);

            return await _inventoryIssueRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);



        }


    }
}
