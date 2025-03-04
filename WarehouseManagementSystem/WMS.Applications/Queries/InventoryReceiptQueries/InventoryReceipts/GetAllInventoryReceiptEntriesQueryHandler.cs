namespace WMS.Application.Queries.InventoryReceiptQueries.InventoryReceipts
{
    public class GetAllInventoryReceiptEntriesQueryHandler : IRequestHandler<GetAllInventoryReceiptEntriesQuery, List<InventoryReceiptEntryDTO>>
    {
        private readonly IInventoryReceiptEntryRepository _inventoryReceiptEntryRepository;
        private readonly IReceiptLotRepository _receiptLotRepository;
        private readonly IMaterialRepository _materialRepository;
        private readonly IMapper _mapper;

        public GetAllInventoryReceiptEntriesQueryHandler(IInventoryReceiptEntryRepository inventoryReceiptEntryRepository, IReceiptLotRepository receiptLotRepository, IMaterialRepository materialRepository, IMapper mapper)
        {
            _inventoryReceiptEntryRepository = inventoryReceiptEntryRepository;
            _receiptLotRepository = receiptLotRepository;
            _materialRepository = materialRepository;
            _mapper = mapper;
        }

        public async Task<List<InventoryReceiptEntryDTO>> Handle(GetAllInventoryReceiptEntriesQuery request, CancellationToken cancellationToken)
        {
            var inventoryReceiptEntries = await _inventoryReceiptEntryRepository.GetAllAsync();
            if (inventoryReceiptEntries == null)
            {
                   throw new Exception("No inventory receipt entries found");
            }

            var inventoryReceiptEntriesDTOs = new List<InventoryReceiptEntryDTO>();

            foreach (var inventoryReceiptEntry in inventoryReceiptEntries)
            {
                var inventoryReceiptEntryDTO = _mapper.Map<InventoryReceiptEntryDTO>(inventoryReceiptEntry);

                var receiptLot = await _receiptLotRepository.GetById(inventoryReceiptEntry.lotNumber);
                inventoryReceiptEntryDTO.ReceiptLot = _mapper.Map<ReceiptLotDTO>(receiptLot);

                var material = await _materialRepository.GetByIdAsync(inventoryReceiptEntry.materialId);
                inventoryReceiptEntryDTO.MapName(material.materialName);


                inventoryReceiptEntriesDTOs.Add(inventoryReceiptEntryDTO);
            }

            return inventoryReceiptEntriesDTOs;
        }
    }
}
