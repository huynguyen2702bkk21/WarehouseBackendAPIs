namespace WMS.Application.Queries.InventoryIssueQueries.InventoryIssues
{
    public class GetAllInventoryIssueEntriesQueryHandler : IRequestHandler<GetAllInventoryIssueEntriesQuery, IEnumerable<InventoryIssueEntryDTO>>
    {
        private readonly IInventoryIssueEntryRepository _inventoryIssueEntryRepository;
        private readonly IMaterialRepository _materialRepository;
        private readonly IMapper _mapper;

        public GetAllInventoryIssueEntriesQueryHandler(IInventoryIssueEntryRepository inventoryIssueEntryRepository, IMaterialRepository materialRepository, IMapper mapper)
        {
            _inventoryIssueEntryRepository = inventoryIssueEntryRepository;
            _materialRepository = materialRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InventoryIssueEntryDTO>> Handle(GetAllInventoryIssueEntriesQuery request, CancellationToken cancellationToken)
        {
            var inventoryIssueEntries = await _inventoryIssueEntryRepository.GetAllInventoryIssueEntriesAsync();
            if (inventoryIssueEntries == null)
            {
                throw new Exception("No inventory issue entries found");
            }

            var inventoryIssueEntryDTOs = new List<InventoryIssueEntryDTO>();

            foreach (var inventoryIssueEntry in inventoryIssueEntries)
            {
                var inventoryIssueEntryDTO = _mapper.Map<InventoryIssueEntryDTO>(inventoryIssueEntry);

                var material = await _materialRepository.GetByIdAsync(inventoryIssueEntry.materialId);
                if (material == null)
                {
                    throw new Exception("Material not found");
                }

                inventoryIssueEntryDTO.MapName(material.materialName);

                inventoryIssueEntryDTOs.Add(inventoryIssueEntryDTO);
            }

            return inventoryIssueEntryDTOs;


        }
    }
}
