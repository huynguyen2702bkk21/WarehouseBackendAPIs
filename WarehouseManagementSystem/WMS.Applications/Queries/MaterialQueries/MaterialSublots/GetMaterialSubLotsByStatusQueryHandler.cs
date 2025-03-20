namespace WMS.Application.Queries.MaterialQueries.MaterialSublots
{
    public class GetMaterialSubLotsByStatusQueryHandler : IRequestHandler<GetMaterialSubLotsByStatusQuery, IEnumerable<MaterialSubLotDTO>>
    {
        private readonly IMaterialSubLotRepository _materialSubLotRepository;
        private readonly IMapper _mapper;

        public GetMaterialSubLotsByStatusQueryHandler(IMaterialSubLotRepository materialSubLotRepository, IMapper mapper)
        {
            _materialSubLotRepository = materialSubLotRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MaterialSubLotDTO>> Handle(GetMaterialSubLotsByStatusQuery request, CancellationToken cancellationToken)
        {
            var materialSubLots = await _materialSubLotRepository.GetMaterialSubLotsByStatus(request.Status);
            if (materialSubLots.Count == 0)
            {
                throw new EntityNotFoundException("MaterialSubLots", "No material sublots found");
            }
            
            var materialSubLotDTOs = _mapper.Map<IEnumerable<MaterialSubLotDTO>>(materialSubLots);

            return materialSubLotDTOs;
        }
    }   
}
