namespace WMS.Application.Queries.InventoryIssueQueries.InventoryIssues
{
    public class GetAllInventoryIssueEntriesQueryHandler : IRequestHandler<GetAllInventoryIssueEntriesQuery, IEnumerable<InventoryIssueEntryDTO>>
    {
        private readonly IInventoryIssueEntryRepository _inventoryIssueEntryRepository;
        private readonly IMapper _mapper;

        public GetAllInventoryIssueEntriesQueryHandler(IInventoryIssueEntryRepository inventoryIssueEntryRepository, IMapper mapper)
        {
            _inventoryIssueEntryRepository = inventoryIssueEntryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InventoryIssueEntryDTO>> Handle(GetAllInventoryIssueEntriesQuery request, CancellationToken cancellationToken)
        {
            var inventoryIssueEntries = await _inventoryIssueEntryRepository.GetAllInventoryIssueEntriesAsync();
            if (inventoryIssueEntries == null)
            {
                throw new Exception("No inventory issue entries found");
            }

            var inventoryIssueEntryDTOs = _mapper.Map<IEnumerable<InventoryIssueEntryDTO>>(inventoryIssueEntries);


            return inventoryIssueEntryDTOs;


        }
    }
}
