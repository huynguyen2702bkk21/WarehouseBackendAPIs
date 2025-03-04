namespace WMS.Application.Queries.MaterialQueries.MaterialSublots
{
    public class GetMaterialSubLotsByLocationIdQueryHandler : IRequestHandler<GetMaterialSubLotsByLocationIdQuery,IEnumerable<MaterialSubLotDTO>>
    {
        private readonly IMaterialSubLotRepository _materialSubLotRepository;
        private readonly IMapper _mapper;

        public GetMaterialSubLotsByLocationIdQueryHandler(IMaterialSubLotRepository materialSubLotRepository, IMapper mapper)
        {
            _materialSubLotRepository = materialSubLotRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MaterialSubLotDTO>> Handle (GetMaterialSubLotsByLocationIdQuery request, CancellationToken cancellationToken)
        {
            var materialSubLots = await _materialSubLotRepository.GetMaterialSubLotsByLocationId(request.LocationId);
            if (materialSubLots == null)
            {
                return null;
            }
            
            var materialSubLotDTOs = _mapper.Map<IEnumerable<MaterialSubLotDTO>>(materialSubLots);

            return materialSubLotDTOs;
        }


    }
}
