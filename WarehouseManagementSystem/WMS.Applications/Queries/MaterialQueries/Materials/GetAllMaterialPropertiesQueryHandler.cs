using DocumentFormat.OpenXml.Wordprocessing;

namespace WMS.Application.Queries.MaterialQueries.Materials
{
    public class GetAllMaterialPropertiesQueryHandler : IRequestHandler<GetAllMaterialPropertiesQuery, IEnumerable<MaterialPropertyDTO>>
    {
        private readonly IMaterialPropertyRepository _materialPropertyRepository;
        private readonly IMapper _mapper;

        public GetAllMaterialPropertiesQueryHandler(IMaterialPropertyRepository materialPropertyRepository, IMapper mapper)
        {
            _materialPropertyRepository = materialPropertyRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MaterialPropertyDTO>> Handle(GetAllMaterialPropertiesQuery request, CancellationToken cancellationToken)
        {
            var materialProperties = await _materialPropertyRepository.GetAllAsync();
            if (materialProperties.Count == 0)
            {
                throw new Exception("Material properties not found");
            }


            var materialPropertyDTOs =  _mapper.Map<IEnumerable<MaterialPropertyDTO>>(materialProperties);

            return materialPropertyDTOs;
        }



    }
}
