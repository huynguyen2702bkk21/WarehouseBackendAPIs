using WMS.Application.Queries.EquipmentQueries.EquipmentClassProperties;

namespace WMS.Application.Queries.EquipmentQueries.EquipmentClasses
{
    public class GetAllEquipmentCLassPropertiesQueryHandler : IRequestHandler<GetAllEquipmentCLassPropertiesQuery, IEnumerable<EquipmentCLassPropertyDTO>>
    {
        private readonly IEquipmentCLassPropertyRepository _equipmentCLassPropertyRepository;
        private readonly IMapper _mapper;

        public GetAllEquipmentCLassPropertiesQueryHandler(IEquipmentCLassPropertyRepository equipmentCLassPropertyRepository, IMapper mapper)
        {
            _equipmentCLassPropertyRepository = equipmentCLassPropertyRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EquipmentCLassPropertyDTO>> Handle(GetAllEquipmentCLassPropertiesQuery request, CancellationToken cancellationToken)
        {
            var equipmentCLassProperties = await _equipmentCLassPropertyRepository.GetAllAsync();

            if (equipmentCLassProperties.Count == 0)
            {
                throw new EntityNotFoundException("No equipment class properties found");
            }

            var equipmentClassPropertyDTOs = _mapper.Map<IEnumerable<EquipmentCLassPropertyDTO>>(equipmentCLassProperties);

            return equipmentClassPropertyDTOs;

        }

    }
}
