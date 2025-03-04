namespace WMS.Application.Queries.MaterialQueries.MaterialLots
{
    public class GetMaterialLotsByStatusQueryHandler : IRequestHandler<GetMaterialLotsByStatusQuery,IEnumerable<MaterialLotDTO>>
    {
        private readonly IMaterialLotRepository _materialLotRepository; 
        private readonly IMapper _mapper;

        public GetMaterialLotsByStatusQueryHandler(IMaterialLotRepository materialLotRepository, IMapper mapper)
        {
            _materialLotRepository = materialLotRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MaterialLotDTO>> Handle(GetMaterialLotsByStatusQuery request, CancellationToken cancellationToken)
        {
            var materialLots = await _materialLotRepository.GetMaterialLotsByStatus(request.Status);

            if (materialLots == null)
            {
                throw new EntityNotFoundException(nameof(MaterialLot), request.Status);
            }
            var materialLotDTOs = _mapper.Map<IEnumerable<MaterialLotDTO>>(materialLots);

            return materialLotDTOs;
        }
    }
}
