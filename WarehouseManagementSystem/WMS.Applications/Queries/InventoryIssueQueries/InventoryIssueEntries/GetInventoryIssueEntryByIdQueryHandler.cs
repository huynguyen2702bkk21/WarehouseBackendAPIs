namespace WMS.Application.Queries.InventoryIssueQueries.InventoryIssues
{
    public class GetInventoryIssueEntryByIdQueryHandler : IRequestHandler<GetInventoryIssueEntryByIdQuery,InventoryIssueEntryDTO>
    {
        private readonly IInventoryIssueEntryRepository _inventoryIssueEntryRepository;
        private readonly IMaterialRepository _materialRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public GetInventoryIssueEntryByIdQueryHandler(IInventoryIssueEntryRepository inventoryIssueEntryRepository, IMaterialRepository materialRepository, IMediator mediator, IMapper mapper)
        {
            _inventoryIssueEntryRepository = inventoryIssueEntryRepository;
            _materialRepository = materialRepository;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<InventoryIssueEntryDTO> Handle(GetInventoryIssueEntryByIdQuery request, CancellationToken cancellationToken)
        {
            var inventoryIssueEntry = await _inventoryIssueEntryRepository.GetInventoryIssueEntryByIdAsync(request.InventoryIssueEntryId);
            if (inventoryIssueEntry == null)
            {
                throw new EntityNotFoundException(nameof(InventoryIssueEntry), request.InventoryIssueEntryId);
            }

            var inventoryIssueEntryDTO = _mapper.Map<InventoryIssueEntryDTO>(inventoryIssueEntry);

            var material = await _materialRepository.GetByIdAsync(inventoryIssueEntry.materialId);
            if (material == null)
            {
                throw new EntityNotFoundException(nameof(Material), inventoryIssueEntry.materialId);
            }

            inventoryIssueEntryDTO.MapName(material.materialName);

            return inventoryIssueEntryDTO;

        }


    }
}
