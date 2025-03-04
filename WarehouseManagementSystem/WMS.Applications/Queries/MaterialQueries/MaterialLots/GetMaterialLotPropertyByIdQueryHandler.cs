namespace WMS.Application.Queries.MaterialQueries.MaterialLots
{
    public class GetMaterialLotPropertyByIdQueryHandler : IRequestHandler<GetMaterialLotPropertyByIdQuery,MaterialLotPropertyDTO>
    {
        private readonly IMaterialLotPropertyRepository _materialLotPropertyRepository;
        private readonly IMapper _mapper;

        public GetMaterialLotPropertyByIdQueryHandler(IMaterialLotPropertyRepository materialLotPropertyRepository, IMapper mapper)
        {
            _materialLotPropertyRepository = materialLotPropertyRepository;
            _mapper = mapper;
        }

        public async Task<MaterialLotPropertyDTO> Handle(GetMaterialLotPropertyByIdQuery request, CancellationToken cancellationToken)
        {
            var materialLotProperty = await _materialLotPropertyRepository.GetMaterialLotPropertyById(request.Id);
            if (materialLotProperty == null)
            {
                throw new EntityNotFoundException(nameof(MaterialLotProperty), request.Id);
            }

            var materialLotPropertyDTO = _mapper.Map<MaterialLotPropertyDTO>(materialLotProperty);

            return materialLotPropertyDTO;


        }


    }
}
