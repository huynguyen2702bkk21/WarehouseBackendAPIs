namespace WMS.Application.Queries.MaterialQueries.Materials
{
    public class GetAllMaterialQueryHandler : IRequestHandler<GetAllMaterialQuery,IEnumerable<MaterialDTO>>
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IMapper _mapper;

        public GetAllMaterialQueryHandler(IMaterialRepository materialRepository, IMapper mapper)
        {
            _materialRepository = materialRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MaterialDTO>> Handle(GetAllMaterialQuery request, CancellationToken cancellationToken)
        {
            var materials = await _materialRepository.GetAllAsync();
            if (materials == null)
            {
                throw new Exception("Materials not found");
            }

            var materialDTOs = _mapper.Map<IEnumerable<MaterialDTO>>(materials);

            return materialDTOs;
        }





    }
}
