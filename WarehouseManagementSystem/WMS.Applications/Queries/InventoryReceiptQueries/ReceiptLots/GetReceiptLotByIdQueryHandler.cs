using WMS.Domain.AggregateModels.InventoryReceiptAggregate;

namespace WMS.Application.Queries.InventoryReceiptQueries.ReceiptLots
{
    public class GetReceiptLotByIdQueryHandler : IRequestHandler<GetReceiptLotByIdQuery, ReceiptLotDTO>
    {
        private readonly IReceiptLotRepository _receiptLotRepository;
        private readonly IMapper _mapper;

        public GetReceiptLotByIdQueryHandler(IReceiptLotRepository receiptLotRepository, IMapper mapper)
        {
            _receiptLotRepository = receiptLotRepository;
            _mapper = mapper;
        }

        public async Task<ReceiptLotDTO> Handle(GetReceiptLotByIdQuery request, CancellationToken cancellationToken)
        {
            var receiptLot = await _receiptLotRepository.GetByIdAsnc(request.ReceiptLotId);
            if (receiptLot == null)
            {
                throw new EntityNotFoundException(nameof(ReceiptLot), request.ReceiptLotId);
            }

            var receiptLotDTO = _mapper.Map<ReceiptLotDTO>(receiptLot);

            return receiptLotDTO;
        }


    }
}
