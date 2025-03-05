namespace WMS.Application.Queries.InventoryIssueQueries.IssueLots
{
    public class GetIssueLotByIdQueryHandler : IRequestHandler<GetIssueLotByIdQuery,IssueLotDTO>
    {
        private readonly IIssueLotRepository _issueLotRepository;
        private readonly IMapper _mapper;

        public GetIssueLotByIdQueryHandler(IIssueLotRepository issueLotRepository, IMapper mapper)
        {
            _issueLotRepository = issueLotRepository;
            _mapper = mapper;
        }

        public async Task<IssueLotDTO> Handle(GetIssueLotByIdQuery request, CancellationToken cancellationToken)
        {
            var issueLot = await _issueLotRepository.GetIssueLotByIdAsync(request.IssueLotId);
            if (issueLot == null)
            {
                throw new Exception("No receipt lot found");
            }

            var issueLotDTO = _mapper.Map<IssueLotDTO>(issueLot);

            return issueLotDTO;

        }


    }
}
