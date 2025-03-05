namespace WMS.Application.Queries.EquipmentQueries.EquipmentClasses
{
    public class GetAllEquipmentCLassesQueryHandler : IRequestHandler<GetAllEquipmentCLassesQuery, IEnumerable<EquipmentCLassDTO>>
    {
        private readonly IEquipmentClassRepository _equipmentClassRepository;
        private readonly IMapper _mapper;

        public GetAllEquipmentCLassesQueryHandler(IEquipmentClassRepository equipmentClassRepository, IMapper mapper)
        {
            _equipmentClassRepository = equipmentClassRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EquipmentCLassDTO>> Handle(GetAllEquipmentCLassesQuery request, CancellationToken cancellationToken)
        {
            var equipmentCLasses = await _equipmentClassRepository.GetAllAsync();
            if (equipmentCLasses == null)
            {
                throw new Exception("No equipment classes found");
            }

            var equipmentClassDTOs = _mapper.Map<IEnumerable<EquipmentCLassDTO>>(equipmentCLasses);

            return equipmentClassDTOs;

        }

    }
}
