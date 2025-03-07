namespace WMS.Application.Queries.EquipmentQueries.Equipments
{
    public class GetEquipmentByIdQueryHandler : IRequestHandler<GetEquipmentByIdQuery, EquipmentDTO>
    {
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IMapper _mapper;

        public GetEquipmentByIdQueryHandler(IEquipmentRepository equipmentRepository, IMapper mapper)
        {
            _equipmentRepository = equipmentRepository;
            _mapper = mapper;
        }

        public async Task<EquipmentDTO> Handle(GetEquipmentByIdQuery request, CancellationToken cancellationToken)
        {
            var equipment = await _equipmentRepository.GetByIdAsync(request.EquipmentId);
            if (equipment == null)
            {
                throw new EntityNotFoundException(nameof(Equipment), request.EquipmentId);
            }

            var equipmentDTO = _mapper.Map<EquipmentDTO>(equipment);

            return equipmentDTO;
        }
    }
}
