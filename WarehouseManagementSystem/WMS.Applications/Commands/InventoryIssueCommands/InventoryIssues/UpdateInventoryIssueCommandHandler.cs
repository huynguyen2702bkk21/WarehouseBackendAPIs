namespace WMS.Application.Commands.InventoryIssueCommands.InventoryIssues
{
    public class UpdateInventoryIssueCommandHandler : IRequestHandler<UpdateInventoryIssueCommand, bool>
    {
        private readonly IInventoryIssueRepository _inventoryIssueRepository;

        public UpdateInventoryIssueCommandHandler(IInventoryIssueRepository inventoryIssueRepository)
        {
            _inventoryIssueRepository = inventoryIssueRepository;
        }

        public async Task<bool> Handle(UpdateInventoryIssueCommand request, CancellationToken cancellationToken)
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

            inventoryIssue.UpdateIssue(customerId: request.CustomerId,
                                       personId: request.PersonId,
                                       warehouseId: request.WarehouseId);

            return await _inventoryIssueRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }



    }
}
