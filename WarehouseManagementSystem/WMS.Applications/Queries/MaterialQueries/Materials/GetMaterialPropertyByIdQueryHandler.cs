namespace WMS.Application.Queries.MaterialQueries.Materials
{
    public class GetMaterialPropertyByIdQueryHandler : IRequestHandler<GetMaterialPropertyByIdQuery, MaterialPropertyDTO>
    {
        private readonly IMaterialPropertyRepository _materialPropertyRepository;
        private readonly IMapper _mapper;

        public GetMaterialPropertyByIdQueryHandler(IMaterialPropertyRepository materialPropertyRepository, IMapper mapper)
        {
            _materialPropertyRepository = materialPropertyRepository;
            _mapper = mapper;
        }

        public async Task<MaterialPropertyDTO> Handle(GetMaterialPropertyByIdQuery request, CancellationToken cancellationToken)
        {
            var materialProperties = await _materialPropertyRepository.GetByIdAsync(request.MaterialPropertyId);
            if (materialProperties == null)
            {
                throw new Exception("Material property not found");
            }

            var materialPropertyDTO = _mapper.Map<MaterialPropertyDTO>(materialProperties);

            return materialPropertyDTO;

        }
    }
}
