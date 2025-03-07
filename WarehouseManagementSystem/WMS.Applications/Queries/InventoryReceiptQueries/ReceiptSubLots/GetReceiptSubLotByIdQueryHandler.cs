using WMS.Domain.AggregateModels.InventoryReceiptAggregate;

namespace WMS.Application.Queries.InventoryReceiptQueries.ReceiptSubLots
{
    public class GetReceiptSubLotByIdQueryHandler : IRequestHandler<GetReceiptSubLotByIdQuery, ReceiptSubLotDTO>
    {
        private readonly IReceiptSubLotRepository _receiptSubLotRepository;
        private readonly IMapper _mapper;

        public GetReceiptSubLotByIdQueryHandler(IReceiptSubLotRepository receiptSubLotRepository, IMapper mapper)
        {
            _receiptSubLotRepository = receiptSubLotRepository;
            _mapper = mapper;
        }

        public async Task<ReceiptSubLotDTO> Handle(GetReceiptSubLotByIdQuery request, CancellationToken cancellationToken)
        {
            var receiptSubLot = await _receiptSubLotRepository.GetByIdAsync(request.ReceiptSublotId);
            if (receiptSubLot == null)
            {
                throw new EntityNotFoundException(nameof(ReceiptSublot), request.ReceiptSublotId);
            }

            var receiptSubLotDTO = _mapper.Map<ReceiptSubLotDTO>(receiptSubLot);

            return receiptSubLotDTO;
        }
    }
}
