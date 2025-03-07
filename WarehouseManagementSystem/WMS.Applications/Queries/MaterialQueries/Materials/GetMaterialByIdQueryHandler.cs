namespace WMS.Application.Queries.MaterialQueries.Materials
{
    public class GetMaterialByIdQueryHandler : IRequestHandler<GetMaterialByIdQuery,MaterialDTO>
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IMapper _mapper;

        public GetMaterialByIdQueryHandler(IMaterialRepository materialRepository, IMapper mapper)
        {
            _materialRepository = materialRepository;
            _mapper = mapper;
        }

        public async Task<MaterialDTO> Handle(GetMaterialByIdQuery request, CancellationToken cancellationToken)
        {
            var materials = await _materialRepository.GetByIdAsync(request.MaterialId);
            if (materials == null)
            {
                throw new EntityNotFoundException(nameof(Material), request.MaterialId);
            }

            var materialDTO = _mapper.Map<MaterialDTO>(materials);

            return materialDTO;
        }

    }
}
