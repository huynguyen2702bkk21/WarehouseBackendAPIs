namespace WMS.Application.Queries.MaterialQueries.MaterialClasses
{
    public class GetMaterialClassPropertyByIdQuerryHandler : IRequestHandler<GetMaterialClassPropertyByIdQuerry, MaterialClassPropertyDTO>
    {
        private readonly IMaterialClassPropertyRepository _materialClassRepository;
        private readonly IMapper _mapper;

        public GetMaterialClassPropertyByIdQuerryHandler(IMaterialClassPropertyRepository materialClassRepository, IMapper mapper)
        {
            _materialClassRepository = materialClassRepository;
            _mapper = mapper;
        }

        public async Task<MaterialClassPropertyDTO> Handle(GetMaterialClassPropertyByIdQuerry request, CancellationToken cancellationToken)
        {
            var materialClassProperty = await _materialClassRepository.GetByIdAsync(request.MaterialClassPropertyId);
            if (materialClassProperty == null)
            {
                throw new EntityNotFoundException(nameof(materialClassProperty),request.MaterialClassPropertyId);
            }
            
            var materialClassPropertyDTO = _mapper.Map<MaterialClassPropertyDTO>(materialClassProperty);

            return materialClassPropertyDTO;
        }


    }
}
