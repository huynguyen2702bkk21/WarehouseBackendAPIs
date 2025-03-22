namespace WMS.Application.Commands.InventoryIssueCommands.IssueLots
{
    public class UpdateIssueLotStatusCommandHandler : IRequestHandler<UpdateIssueLotStatusCommand,bool>
    {
        private readonly IInventoryIssueRepository _inventoryIssueRepository;

        public UpdateIssueLotStatusCommandHandler(IInventoryIssueRepository inventoryIssueRepository)
        {
            _inventoryIssueRepository = inventoryIssueRepository;
        }

        public async Task<bool> Handle(UpdateIssueLotStatusCommand request, CancellationToken cancellationToken)
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

            var inventoryIssueEntry = inventoryIssue.entries
                .FirstOrDefault(x => x.inventoryIssueEntryId == request.InventoryIssueEntryId);

            if (inventoryIssueEntry == null)
            {
                throw new EntityNotFoundException(nameof(InventoryIssueEntry), request.InventoryIssueEntryId);
            }

            if (inventoryIssueEntry.issueLot == null)
            {
                throw new EntityNotFoundException(nameof(IssueLot), request.IssueLotId);
            }

            if (!Enum.TryParse(request.IssueLotStatus, true, out LotStatus lotStatus))
            {
                throw new ArgumentException($"Invalid receiptLot status: {request.IssueLotStatus}");
            }

            inventoryIssueEntry.issueLot.Update(lotStatus);

            return await _inventoryIssueRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }



    }
}
