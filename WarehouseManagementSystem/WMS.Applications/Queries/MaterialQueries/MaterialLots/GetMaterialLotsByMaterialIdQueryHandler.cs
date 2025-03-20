using Azure.Core;

namespace WMS.Application.Queries.MaterialQueries.MaterialLots
{
    public class GetMaterialLotsByMaterialIdQueryHandler : IRequestHandler<GetMaterialLotsByMaterialIdQuery, IEnumerable<MaterialLotDTO>>
    {
        private readonly IMaterialLotRepository _materialLotRepository;
        private readonly IMapper _mapper;

        public GetMaterialLotsByMaterialIdQueryHandler(IMaterialLotRepository materialLotRepository, IMapper mapper)
        {
            _materialLotRepository = materialLotRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MaterialLotDTO>> Handle(GetMaterialLotsByMaterialIdQuery request, CancellationToken cancellationToken)
        {
            var materialLots = await _materialLotRepository.GetMaterialLotsByMaterialId(request.MaterialId);
            if (materialLots.Count == 0)
            {
                throw new EntityNotFoundException(nameof(MaterialLot), request.MaterialId);
            }

            var materialLotDTOs = _mapper.Map<IEnumerable<MaterialLotDTO>>(materialLots);
            return materialLotDTOs;
        }
    }
}
