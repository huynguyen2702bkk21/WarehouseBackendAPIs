using WMS.Application.DTOs.EquipmentDTOs.EquipmentClasses;
using WMS.Domain.AggregateModels.MaterialAggregate;

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
            if (equipmentCLasses.Count == 0)
            {
                throw new EntityNotFoundException("EquipmentClasses is Null");
            }

            var equipmentClassDTOs = _mapper.Map<IEnumerable<EquipmentCLassDTO>>(equipmentCLasses);

            return equipmentClassDTOs;

        }

    }
}
