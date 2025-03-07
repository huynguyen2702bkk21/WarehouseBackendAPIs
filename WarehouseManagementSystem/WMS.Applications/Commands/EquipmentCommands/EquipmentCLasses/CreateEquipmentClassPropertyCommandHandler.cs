namespace WMS.Application.Commands.EquipmentCommands.EquipmentCLasses
{
    public class CreateEquipmentClassPropertyCommandHandler : IRequestHandler<CreateEquipmentClassPropertyCommand,bool>
    {
        private readonly IEquipmentCLassPropertyRepository _equipmentCLassPropertyRepository;

        public CreateEquipmentClassPropertyCommandHandler(IEquipmentCLassPropertyRepository equipmentCLassPropertyRepository)
        {
            _equipmentCLassPropertyRepository = equipmentCLassPropertyRepository;
        }

        public async Task<bool> Handle(CreateEquipmentClassPropertyCommand request, CancellationToken cancellationToken)
        {
            var euipmentClassProperty = await _equipmentCLassPropertyRepository.GetByIdAsync(request.PropertyId);
            if (euipmentClassProperty != null)
            {
                throw new DuplicateRecordException(nameof(EquipmentClassProperty), request.PropertyId);
            }

            if (!Enum.TryParse<UnitOfMeasure>(request.UnitOfMeasure, out var unitOfMeasure))
            {
                throw new ArgumentException("Invalid status value", nameof(request.UnitOfMeasure));
            }

            var newEquipmentClassProperty = new EquipmentClassProperty(propertyId: request.PropertyId,
                                                                       propertyName: request.PropertyName,
                                                                       propertyValue: request.PropertyValue,
                                                                       unitOfMeasure: unitOfMeasure,
                                                                       equipmentClassId: request.EquipmentClassId);

            _equipmentCLassPropertyRepository.Create(newEquipmentClassProperty);

            return await _equipmentCLassPropertyRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        }
    }
}
