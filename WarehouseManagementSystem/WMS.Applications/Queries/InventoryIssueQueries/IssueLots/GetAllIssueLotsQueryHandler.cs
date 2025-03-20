namespace WMS.Application.Queries.InventoryIssueQueries.IssueLots
{
    public class GetAllIssueLotsQueryHandler : IRequestHandler<GetAllIssueLotsQuery, IEnumerable<IssueLotDTO>>
    {
        private readonly IIssueLotRepository _issueLotRepository;
        private readonly IMapper _mapper;

        public GetAllIssueLotsQueryHandler(IIssueLotRepository issueLotRepository, IMapper mapper)
        {
            _issueLotRepository = issueLotRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<IssueLotDTO>> Handle(GetAllIssueLotsQuery request, CancellationToken cancellationToken)
        {
            var issueLots = await _issueLotRepository.GetAllIssueLotsAsync();
            if (issueLots.Count == 0)
            {
                throw new Exception("No receipt lots found");
            }

            var issueLotsDTOs = _mapper.Map<IEnumerable<IssueLotDTO>>(issueLots);

            return issueLotsDTOs;

        }



    }
}
