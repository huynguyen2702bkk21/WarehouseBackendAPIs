namespace WMS.Application.Commands.InventoryIssueCommands.InventoryIssues
{
    public class RefreshInventoryIssueStatusCommandHandler : IRequestHandler<RefreshInventoryIssueStatusCommand,bool>
    {
        private readonly IInventoryIssueRepository _inventoryIssueRepository;
        private readonly IIssueServices _issueServices;

        public RefreshInventoryIssueStatusCommandHandler(IInventoryIssueRepository inventoryIssueRepository, IIssueServices issueServices)
        {
            _inventoryIssueRepository = inventoryIssueRepository;
            _issueServices = issueServices;
        }

        public async Task<bool> Handle(RefreshInventoryIssueStatusCommand request, CancellationToken cancellationToken)
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

            await _issueServices.UpdateMaterialLot(inventoryIssue);

            return await _inventoryIssueRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }


    }
}
