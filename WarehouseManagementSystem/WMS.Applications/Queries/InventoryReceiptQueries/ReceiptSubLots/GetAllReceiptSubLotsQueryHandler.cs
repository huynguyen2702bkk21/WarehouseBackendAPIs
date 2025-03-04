namespace WMS.Application.Queries.InventoryReceiptQueries.ReceiptSubLots
{
    public class GetAllReceiptSubLotsQueryHandler : IRequestHandler<GetAllReceiptSubLotsQuery, IEnumerable<ReceiptSubLotDTO>>
    {
        private readonly IReceiptSubLotRepository _receiptSubLotRepository;
        private readonly IMapper _mapper;

        public GetAllReceiptSubLotsQueryHandler(IReceiptSubLotRepository receiptSubLotRepository, IMapper mapper)
        {
            _receiptSubLotRepository = receiptSubLotRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReceiptSubLotDTO>> Handle(GetAllReceiptSubLotsQuery request, CancellationToken cancellationToken)
        {
            var receiptSubLots = await _receiptSubLotRepository.GetAllAsync();
            if (receiptSubLots == null)
            {
                throw new Exception("No receipt sub lots found");
            }

            var receiptSubLotsDTOs = _mapper.Map<IEnumerable<ReceiptSubLotDTO>>(receiptSubLots);

            return receiptSubLotsDTOs;
        }
    }
}
