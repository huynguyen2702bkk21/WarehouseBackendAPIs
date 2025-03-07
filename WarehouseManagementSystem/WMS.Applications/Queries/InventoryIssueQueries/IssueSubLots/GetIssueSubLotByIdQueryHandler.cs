namespace WMS.Application.Queries.InventoryIssueQueries.IssueSubLots
{
    public class GetIssueSubLotByIdQueryHandler : IRequestHandler<GetIssueSubLotByIdQuery, IssueSubLotDTO>
    {
        private readonly IIssueSubLotRepository _issueSubLotRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public GetIssueSubLotByIdQueryHandler(IIssueSubLotRepository issueSubLotRepository, IMediator mediator, IMapper mapper)
        {
            _issueSubLotRepository = issueSubLotRepository;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IssueSubLotDTO> Handle(GetIssueSubLotByIdQuery request, CancellationToken cancellationToken)
        {
            var issueSubLot = await _issueSubLotRepository.GetByIdAsync(request.IssueSublotId);
            if (issueSubLot == null)
            {
                throw new EntityNotFoundException("IssueSubLot", request.IssueSublotId);
            }

            var materialSubLot = await _mediator.Send(new GetMaterialSubLotByIdQuery(issueSubLot.sublotId));
            if (materialSubLot == null)
            {
                throw new EntityNotFoundException("MaterialSubLot", issueSubLot.sublotId);
            }
            var issueSubLotDTO = new IssueSubLotDTO(issueSublotId: issueSubLot.issueSublotId,
                                                    requestedQuantity: issueSubLot.requestedQuantity,
                                                    materialSublot: materialSubLot,
                                                    issueLotId: issueSubLot.issueLotId);

            return issueSubLotDTO;
        }

    }

    
}

