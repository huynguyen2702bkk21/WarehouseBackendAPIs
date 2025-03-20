namespace WMS.Application.Queries.MaterialQueries.Materials
{
    public class GetMaterialsByClassIdQueryHandler : IRequestHandler<GetMaterialsByClassIdQuery, IEnumerable<MaterialDTO>>
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IMapper _mapper;

        public GetMaterialsByClassIdQueryHandler(IMaterialRepository materialRepository, IMapper mapper)
        {
            _materialRepository = materialRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MaterialDTO>> Handle(GetMaterialsByClassIdQuery request, CancellationToken cancellationToken)
        {
            var materials = await _materialRepository.GetByClassIdAsync(request.ClassId);
            if (materials.Count == 0)
            {
                throw new EntityNotFoundException("Materials not found");
            }

            var materialDTOs = _mapper.Map<IEnumerable<MaterialDTO>>(materials);

            return materialDTOs;
        }


    }
}
