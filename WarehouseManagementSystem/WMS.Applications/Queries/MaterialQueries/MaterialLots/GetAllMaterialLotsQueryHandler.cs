namespace WMS.Application.Queries.MaterialQueries.MaterialLots
{
    public class GetAllMaterialLotsQueryHandler : IRequestHandler<GetAllMaterialLotsQuery,IEnumerable<MaterialLotDTO>>
    {
        private readonly IMaterialLotRepository _materialLotRepository;
        private readonly IMapper _mapper;

        public GetAllMaterialLotsQueryHandler(IMaterialLotRepository materialLotRepository, IMapper mapper)
        {
            _materialLotRepository = materialLotRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MaterialLotDTO>> Handle(GetAllMaterialLotsQuery request, CancellationToken cancellationToken)
        {
            var materialLots = await _materialLotRepository.GetAllAsync();
            if (materialLots.Count == 0)
            {
                throw new Exception("Material lots not found");
            }

            var materialLotsDTOs = _mapper.Map<IEnumerable<MaterialLotDTO>>(materialLots);
            
            return materialLotsDTOs;
        }



    }
}
