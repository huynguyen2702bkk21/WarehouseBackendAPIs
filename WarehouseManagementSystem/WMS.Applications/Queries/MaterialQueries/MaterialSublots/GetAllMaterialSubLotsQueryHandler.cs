namespace WMS.Application.Queries.MaterialQueries.MaterialSublots
{
    public class GetAllMaterialSubLotsQueryHandler : IRequestHandler<GetAllMaterialSubLotsQuery,IEnumerable<MaterialSubLotDTO>>
    {
        private readonly IMaterialSubLotRepository _materialSubLotRepository;
        private readonly IMapper _mapper;

        public GetAllMaterialSubLotsQueryHandler(IMaterialSubLotRepository materialSubLotRepository, IMapper mapper)
        {
            _materialSubLotRepository = materialSubLotRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MaterialSubLotDTO>> Handle(GetAllMaterialSubLotsQuery request, CancellationToken cancellation)
        {
            var materialSubLots = await _materialSubLotRepository.GetAllAsync();
            if (materialSubLots == null)
            {
                return null;
            }
            
            var materialSubLotDTOs = _mapper.Map<IEnumerable<MaterialSubLotDTO>>(materialSubLots);

            return materialSubLotDTOs;
        }


    }
}
