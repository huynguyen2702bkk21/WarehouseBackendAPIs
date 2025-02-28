namespace WMS.Application.Queries.MaterialQueries.MaterialClasses
{
    public class GetMaterialClassByIdQueryHandler : IRequestHandler<GetMaterialClassByIdQuery, MaterialClassDTO>
    {
        private readonly IMaterialClassRepository _materialClassRepository;
        private readonly IMapper _mapper;

        public GetMaterialClassByIdQueryHandler(IMaterialClassRepository materialClassRepository, IMapper mapper)
        {
            _materialClassRepository = materialClassRepository;
            _mapper = mapper;
        }

        public async Task<MaterialClassDTO> Handle(GetMaterialClassByIdQuery request, CancellationToken cancellationToken)
        {
            var materialClass = await _materialClassRepository.GetByIdAsync(request.MaterialClassId);
            if (materialClass == null)
            {
                throw new EntityNotFoundException(nameof(MaterialClasses),request.MaterialClassId);
            }
            
            var materialClassDTO = _mapper.Map<MaterialClassDTO>(materialClass);

            return materialClassDTO;
        }


    }
}
