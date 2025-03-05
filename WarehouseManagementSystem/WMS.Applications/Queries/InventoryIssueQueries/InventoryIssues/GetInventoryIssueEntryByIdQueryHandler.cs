using WMS.Application.DTOs.InventoryIssueDTOs;
using WMS.Application.Queries.InventoryIssueQueries.IssueLots;
using WMS.Domain.AggregateModels.InventoryIssueAggregate;

namespace WMS.Application.Queries.InventoryIssueQueries.InventoryIssues
{
    public class GetInventoryIssueEntryByIdQueryHandler : IRequestHandler<GetInventoryIssueEntryByIdQuery,InventoryIssueEntryDTO>
    {
        private readonly IInventoryIssueEntryRepository _inventoryIssueEntryRepository;
        private readonly IMaterialRepository _materialRepository;
        private readonly IMediator _mediator;

        public GetInventoryIssueEntryByIdQueryHandler(IInventoryIssueEntryRepository inventoryIssueEntryRepository, IMaterialRepository materialRepository, IMediator mediator)
        {
            _inventoryIssueEntryRepository = inventoryIssueEntryRepository;
            _materialRepository = materialRepository;
            _mediator = mediator;
        }

        public async Task<InventoryIssueEntryDTO> Handle(GetInventoryIssueEntryByIdQuery request, CancellationToken cancellationToken)
        {
            var inventoryIssueEntry = await _inventoryIssueEntryRepository.GetInventoryIssueEntryByIdAsync(request.InventoryIssueEntryId);
            if (inventoryIssueEntry == null)
            {
                throw new Exception("No inventory issue entry found");
            }
            
            var issueLot = await _mediator.Send(new GetIssueLotByIdQuery(inventoryIssueEntry.issueLotId));
            if (issueLot == null)
            {
                throw new Exception("Issue lot not found");
            }
            var material = await _materialRepository.GetByIdAsync(inventoryIssueEntry.materialId);

            var inventoryIssueEntryDTO = new InventoryIssueEntryDTO(inventoryIssueEntryId: inventoryIssueEntry.inventoryIssueEntryId,
                                                                    purchaseOrderNumber: inventoryIssueEntry.purchaseOrderNumber,
                                                                    requestedQuantity: inventoryIssueEntry.requestedQuantity,
                                                                    note: inventoryIssueEntry.note,
                                                                    materialName: material.materialName,
                                                                    inventoryIssueId: inventoryIssueEntry.inventoryIssueId,
                                                                    issueLot: issueLot);

            return inventoryIssueEntryDTO;

        }


    }
}
