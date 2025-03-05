namespace WMS.Application.Queries.EquipmentQueries.Equipments
{
    public class GetAllEquipmentsQueryHandler : IRequestHandler<GetAllEquipmentsQuery, IEnumerable<EquipmentDTO>>
    {
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IMapper _mapper;

        public GetAllEquipmentsQueryHandler(IEquipmentRepository equipmentRepository, IMapper mapper)
        {
            _equipmentRepository = equipmentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EquipmentDTO>> Handle(GetAllEquipmentsQuery request, CancellationToken cancellationToken)
        {
            var equipments = await _equipmentRepository.GetAllAsync();
            if (equipments == null)
            {
                throw new EntityNotFoundException(nameof(Equipments));
            }

            var equipmentsDTO = _mapper.Map<IEnumerable<EquipmentDTO>>(equipments);

            return equipmentsDTO;
        }
    }
}
