using WMS.Application.Queries.InventoryReceiptQueries.InventoryReceipts;
using WMS.Domain.AggregateModels.InventoryReceiptAggregate;

namespace WMS.Application.Queries.InventoryReceiptQueries.InventoryReceiptEntries
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
                throw new EntityNotFoundException(nameof(InventoryReceiptEntry), request.InventoryReceiptEntryId);
            }

            var inventoryReceiptEntryDTO = _mapper.Map<InventoryReceiptEntryDTO>(inventoryReceiptEntry);

            var receiptLot = await _receiptLotRepository.GetByIdAsnc(inventoryReceiptEntry.lotNumber);
            if (receiptLot == null)
            {
                throw new EntityNotFoundException(nameof(ReceiptLot), inventoryReceiptEntry.lotNumber);
            }

            inventoryReceiptEntryDTO.ReceiptLot = _mapper.Map<ReceiptLotDTO>(receiptLot);

            var material = await _materialRepository.GetByIdAsync(inventoryReceiptEntry.materialId);
            if (material == null)
            {
                throw new EntityNotFoundException(nameof(Material), inventoryReceiptEntry.materialId);
            }

            inventoryReceiptEntryDTO.MapName(material.materialName);

            return inventoryReceiptEntryDTO;
        }


    }
}
