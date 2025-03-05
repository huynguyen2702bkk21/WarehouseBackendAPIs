namespace WMS.Application.Queries.EquipmentQueries.EquipmentClasses
{
    public class GetEquipmentCLassByIdQueryHandler : IRequestHandler<GetEquipmentCLassByIdQuery, EquipmentCLassDTO>
    {
        private readonly IEquipmentClassRepository _equipmentClassRepository;
        private readonly IMapper _mapper;

        public GetEquipmentCLassByIdQueryHandler(IEquipmentClassRepository equipmentClassRepository, IMapper mapper)
        {
            _equipmentClassRepository = equipmentClassRepository;
            _mapper = mapper;
        }

        public async Task<EquipmentCLassDTO> Handle(GetEquipmentCLassByIdQuery request, CancellationToken cancellationToken)
        {
            var equipmentClass = await _equipmentClassRepository.GetByIdAsync(request.EquipmentCLassId);
            if (equipmentClass == null)
            {
                throw new Exception("No equipment class found");
            }

            var equipmentClassDTO = _mapper.Map<EquipmentCLassDTO>(equipmentClass);

            return equipmentClassDTO;
        }
    }
}
