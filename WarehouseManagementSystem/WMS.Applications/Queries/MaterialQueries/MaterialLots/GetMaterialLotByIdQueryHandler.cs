namespace WMS.Application.Queries.MaterialQueries.MaterialLots
{
    public class GetMaterialLotByIdQueryHandler : IRequestHandler<GetMaterialLotByIdQuery,MaterialLotDTO>
    {
        private readonly IMaterialLotRepository _materialLotRepository; 
        private readonly IMapper _mapper;

        public GetMaterialLotByIdQueryHandler(IMaterialLotRepository materialLotRepository, IMapper mapper)
        {
            _materialLotRepository = materialLotRepository;
            _mapper = mapper;
        }

        public async Task<MaterialLotDTO> Handle(GetMaterialLotByIdQuery request, CancellationToken cancellationToken)
        {
            var materialLot = await _materialLotRepository.GetMaterialLotById(request.LotNumber);

            if (materialLot == null)
            {
                throw new EntityNotFoundException(nameof(MaterialLot), request.LotNumber);
            }
            var materialLotDTO = _mapper.Map<MaterialLotDTO>(materialLot);

            return materialLotDTO;
        }

    }
}
