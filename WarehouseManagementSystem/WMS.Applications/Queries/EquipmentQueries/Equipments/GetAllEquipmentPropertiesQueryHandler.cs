﻿namespace WMS.Application.Queries.EquipmentQueries.EquipmentProperties
{
    public class GetAllEquipmentPropertiesQueryHandler : IRequestHandler<GetAllEquipmentPropertiesQuery, IEnumerable<EquipmentPropertyDTO>>
    {
        private readonly IEquipmentPropertyRepository _equipmentPropertyRepository;
        private readonly IMapper _mapper;

        public GetAllEquipmentPropertiesQueryHandler(IEquipmentPropertyRepository equipmentPropertyRepository, IMapper mapper)
        {
            _equipmentPropertyRepository = equipmentPropertyRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EquipmentPropertyDTO>> Handle(GetAllEquipmentPropertiesQuery request, CancellationToken cancellationToken)
        {
            var equipmentProperties = await _equipmentPropertyRepository.GetAllAsync();
            if (equipmentProperties.Count == 0) 
            {
                throw new EntityNotFoundException("EquipmentProperties has not Existed");
            }

            var equipmentPropertiesDTO = _mapper.Map<IEnumerable<EquipmentPropertyDTO>>(equipmentProperties);

            return equipmentPropertiesDTO;
        }


    }
}
