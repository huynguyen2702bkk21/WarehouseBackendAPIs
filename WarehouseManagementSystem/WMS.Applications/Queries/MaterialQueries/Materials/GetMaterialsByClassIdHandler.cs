namespace WMS.Application.Queries.MaterialQueries.Materials
{
    public class GetMaterialsByClassIdHandler : IRequestHandler<GetMaterialsByClassId, MaterialClassDTO>
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IMapper _mapper;

        public GetMaterialsByClassIdHandler(IMaterialRepository materialRepository, IMapper mapper)
        {
            _materialRepository = materialRepository;
            _mapper = mapper;
        }

        public async Task<MaterialClassDTO> Handle(GetMaterialsByClassId request, CancellationToken cancellationToken)
        {
            var materials = await _materialRepository.GetByClassIdAsync(request.ClassId);
            if (materials == null)
            {
                throw new Exception("Materials not found");
            }

            var materialDTOs = _mapper.Map<MaterialClassDTO>(materials);

            return materialDTOs;
        }


    }
}
