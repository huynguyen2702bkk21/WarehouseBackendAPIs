namespace WMS.Application.Queries.InventoryReceiptQueries.InventoryReceipts
{
    public class GetInventoryReceiptEntryByIdQueryHandler : IRequestHandler<GetInventoryReceiptEntryByIdQuery, InventoryReceiptEntryDTO>
    {
        private readonly IInventoryReceiptEntryRepository _inventoryReceiptEntryRepository; 
        private readonly IReceiptLotRepository _receiptLotRepository;
        private readonly IMaterialRepository _materialRepository;
        private readonly IMapper _mapper;

        public GetInventoryReceiptEntryByIdQueryHandler(IInventoryReceiptEntryRepository inventoryReceiptEntryRepository, IReceiptLotRepository receiptLotRepository, IMaterialRepository materialRepository, IMapper mapper)
        {
            _inventoryReceiptEntryRepository = inventoryReceiptEntryRepository;
            _receiptLotRepository = receiptLotRepository;
            _materialRepository = materialRepository;
            _mapper = mapper;
        }

        public async Task<InventoryReceiptEntryDTO> Handle(GetInventoryReceiptEntryByIdQuery request, CancellationToken cancellationToken)
        {
            var inventoryReceiptEntry = await _inventoryReceiptEntryRepository.GetById(request.InventoryReceiptEntryId);
            if (inventoryReceiptEntry == null)
            {
                throw new Exception("No inventory receipt entry found");
            }

            var inventoryReceiptEntryDTO = _mapper.Map<InventoryReceiptEntryDTO>(inventoryReceiptEntry);

            var receiptLot = await _receiptLotRepository.GetByIdAsnc(inventoryReceiptEntry.lotNumber);
            inventoryReceiptEntryDTO.ReceiptLot = _mapper.Map<ReceiptLotDTO>(receiptLot);

            var material = await _materialRepository.GetByIdAsync(inventoryReceiptEntry.materialId);
            inventoryReceiptEntryDTO.MapName(material.materialName);

            return inventoryReceiptEntryDTO;
        }


    }
}
