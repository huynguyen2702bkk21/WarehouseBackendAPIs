namespace WMS.Application.Queries.MaterialQueries.MaterialClasses
{
    public class GetAllMaterialClassPropertiesQuerryHandler : IRequestHandler<GetAllMaterialClassPropertiesQuerry, IEnumerable<MaterialClassPropertyDTO>>
    {
        private readonly IMaterialClassPropertyRepository _materialClassPropertyRepository;
        private readonly IMapper _mapper;

        public GetAllMaterialClassPropertiesQuerryHandler(IMaterialClassPropertyRepository materialClassPropertyRepository, IMapper mapper)
        {
            _materialClassPropertyRepository = materialClassPropertyRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MaterialClassPropertyDTO>> Handle(GetAllMaterialClassPropertiesQuerry request, CancellationToken cancellationToken)
        {
            var materialClassProperties = await _materialClassPropertyRepository.GetAllAsync();
            if (materialClassProperties == null)
            {
                throw new EntityNotFoundException("MaterialClassProperties", "No material class properties found");
            }
            
            var materialClassPropertyDTOs = _mapper.Map<IEnumerable<MaterialClassPropertyDTO>>(materialClassProperties);

            return materialClassPropertyDTOs;
        }


    }
}
