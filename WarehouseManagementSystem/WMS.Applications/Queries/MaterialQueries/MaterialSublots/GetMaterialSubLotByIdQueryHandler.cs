namespace WMS.Application.Queries.MaterialQueries.MaterialSublots
{
    public class GetMaterialSubLotByIdQueryHandler : IRequestHandler<GetMaterialSubLotByIdQuery, MaterialSubLotDTO>
    {
        private readonly IMaterialSubLotRepository _materialSubLotRepository;
        private readonly IMapper _mapper;

        public GetMaterialSubLotByIdQueryHandler(IMaterialSubLotRepository materialSubLotRepository, IMapper mapper)
        {
            _materialSubLotRepository = materialSubLotRepository;
            _mapper = mapper;
        }

        public GetMaterialSubLotByIdQueryHandler()
        {
        }

        public async Task<MaterialSubLotDTO> Handle(GetMaterialSubLotByIdQuery request, CancellationToken cancellationToken)
        {
            var materialSubLot = await _materialSubLotRepository.GetByIdAsync(request.Id);
            if (materialSubLot == null)
            {
                throw new EntityNotFoundException(nameof(materialSubLot), request.Id);
            }

            var materialSubLotDTO = _mapper.Map<MaterialSubLotDTO>(materialSubLot);

            return materialSubLotDTO;


        }
    }
}
