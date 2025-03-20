namespace WMS.Application.Queries.MaterialQueries.MaterialLots
{
    public class GetAllMaterialLotPropertiesQueryHandler : IRequestHandler<GetAllMaterialLotPropertiesQuery, IEnumerable<MaterialLotPropertyDTO>>
    {
        private readonly IMaterialLotPropertyRepository _materialLotPropertyRepository;
        private readonly IMapper _mapper;

        public GetAllMaterialLotPropertiesQueryHandler(IMaterialLotPropertyRepository materialLotPropertyRepository, IMapper mapper)
        {
            _materialLotPropertyRepository = materialLotPropertyRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MaterialLotPropertyDTO>> Handle(GetAllMaterialLotPropertiesQuery request, CancellationToken cancellationToken)
        {
            var materialLotProperties = await _materialLotPropertyRepository.GetAllAsync();
            if (materialLotProperties.Count == 0)
            {
                throw new Exception("Material lot properties not found");
            }

            var materialLotPropertiesDTOs = _mapper.Map<IEnumerable<MaterialLotPropertyDTO>>(materialLotProperties);
            
            return materialLotPropertiesDTOs;
        }
    }
}
