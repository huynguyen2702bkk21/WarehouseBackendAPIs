﻿namespace WMS.Application.Queries.EquipmentQueries.EquipmentClassProperties
{
    public class GetEquipmentCLassPropertyByIdQueryHandler : IRequestHandler<GetEquipmentCLassPropertyByIdQuery,EquipmentCLassPropertyDTO>
    {
        private readonly IEquipmentCLassPropertyRepository _equipmentCLassPropertyRepository;
        private readonly IMapper _mapper;

        public GetEquipmentCLassPropertyByIdQueryHandler(IEquipmentCLassPropertyRepository equipmentCLassPropertyRepository, IMapper mapper)
        {
            _equipmentCLassPropertyRepository = equipmentCLassPropertyRepository;
            _mapper = mapper;
        }

        public async Task<EquipmentCLassPropertyDTO> Handle(GetEquipmentCLassPropertyByIdQuery request, CancellationToken cancellationToken)
        {
            var equipmentCLassProperty = await _equipmentCLassPropertyRepository.GetByIdAsync(request.EquipmentClassPropertyId);
            if (equipmentCLassProperty == null)
            {
                throw new Exception("No equipment class property found");
            }

            var equipmentClassPropertyDTO = _mapper.Map<EquipmentCLassPropertyDTO>(equipmentCLassProperty);

            return equipmentClassPropertyDTO;
        }

    }
}
