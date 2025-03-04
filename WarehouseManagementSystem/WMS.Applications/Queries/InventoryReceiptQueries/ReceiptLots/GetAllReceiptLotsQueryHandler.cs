namespace WMS.Application.Queries.InventoryReceiptQueries.ReceiptLots
{
    public class GetAllReceiptLotsQueryHandler : IRequestHandler<GetAllReceiptLotsQuery, IEnumerable<ReceiptLotDTO>>
    {
        private readonly IReceiptLotRepository _receiptLotRepository;
        private readonly IMapper _mapper;

        public GetAllReceiptLotsQueryHandler(IReceiptLotRepository receiptLotRepository, IMapper mapper)
        {
            _receiptLotRepository = receiptLotRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReceiptLotDTO>> Handle(GetAllReceiptLotsQuery request, CancellationToken cancellationToken)
        {
            var receiptLots = await _receiptLotRepository.GetAllAsync();
            if (receiptLots == null)
            {
                throw new Exception("No receipt lots found");
            }

            var receiptLotsDTOs = _mapper.Map<IEnumerable<ReceiptLotDTO>>(receiptLots);  

            return receiptLotsDTOs;
        }

    }
}
