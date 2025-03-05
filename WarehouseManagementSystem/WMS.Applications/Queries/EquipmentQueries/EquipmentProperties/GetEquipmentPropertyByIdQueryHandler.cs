namespace WMS.Application.Queries.EquipmentQueries.EquipmentProperties
{
    public class GetEquipmentPropertyByIdQueryHandler : IRequestHandler<GetEquipmentPropertyByIdQuery, EquipmentPropertyDTO>
    {
        private readonly IEquipmentPropertyRepository _equipmentPropertyRepository;
        private readonly IMapper _mapper;

        public GetEquipmentPropertyByIdQueryHandler(IEquipmentPropertyRepository equipmentPropertyRepository, IMapper mapper)
        {
            _equipmentPropertyRepository = equipmentPropertyRepository;
            _mapper = mapper;
        }

        public async Task<EquipmentPropertyDTO> Handle(GetEquipmentPropertyByIdQuery request, CancellationToken cancellationToken)
        {
            var equipmentProperty = await _equipmentPropertyRepository.GetByIdAsync(request.PropertyId);
            if (equipmentProperty == null)
            {
                throw new EntityNotFoundException(nameof(EquipmentProperty));
            }

            var equipmentPropertyDTO = _mapper.Map<EquipmentPropertyDTO>(equipmentProperty);

            return equipmentPropertyDTO;
        }


    }
}
