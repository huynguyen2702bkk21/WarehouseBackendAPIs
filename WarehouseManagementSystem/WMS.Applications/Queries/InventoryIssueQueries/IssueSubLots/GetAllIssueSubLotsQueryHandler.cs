using WMS.Application.Queries.MaterialQueries.MaterialSublots;
using WMS.Domain.AggregateModels.InventoryIssueAggregate;
using WMS.Domain.InterfaceRepositories.IInventoryIssue;

namespace WMS.Application.Queries.InventoryIssueQueries.IssueSubLots
{
    public class GetAllIssueSubLotsQueryHandler : IRequestHandler<GetAllIssueSubLotsQuery, IEnumerable<IssueSubLotDTO>>
    {
        private readonly IIssueSubLotRepository _issueSubLotRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public GetAllIssueSubLotsQueryHandler(IIssueSubLotRepository issueSubLotRepository, IMediator mediator, IMapper mapper)
        {
            _issueSubLotRepository = issueSubLotRepository;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IEnumerable<IssueSubLotDTO>> Handle(GetAllIssueSubLotsQuery request, CancellationToken cancellationToken)
        {
            var issueSubLots = await _issueSubLotRepository.GetAllAsync();
            if (issueSubLots == null)
            {
                throw new Exception("No issue sub lots found");
            }

            var issueSubLotsDTOs = new List<IssueSubLotDTO>();

            foreach (var issueSubLot in issueSubLots)
            {
                var materialSubLot = await _mediator.Send(new GetMaterialSubLotByIdQuery(issueSubLot.sublotId));
                if (materialSubLot == null)
                {
                    throw new Exception("Material sub lot not found");
                }
                var issueSubLotDTO = new IssueSubLotDTO(issueSublotId: issueSubLot.issueSublotId,
                                                        requestedQuantity: issueSubLot.requestedQuantity,
                                                        materialSublot: materialSubLot,
                                                        issueLotId: issueSubLot.issueLotId);

                issueSubLotsDTOs.Add(issueSubLotDTO);
            }

            return issueSubLotsDTOs;
        }

    }
}
