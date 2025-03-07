namespace WMS.Application.Commands.EquipmentCommands.Equipments
{
    public class CreateEquipmentCommandHandler : IRequestHandler<CreateEquipmentCommand, bool>
    {
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IEquipmentPropertyRepository _equipmentPropertyRepository;
        private readonly IEquipmentClassRepository _equipmentClassRepository;

        public CreateEquipmentCommandHandler(IEquipmentRepository equipmentRepository, IEquipmentPropertyRepository equipmentPropertyRepository, IEquipmentClassRepository equipmentClassRepository)
        {
            _equipmentRepository = equipmentRepository;
            _equipmentPropertyRepository = equipmentPropertyRepository;
            _equipmentClassRepository = equipmentClassRepository;
        }

        public async Task<bool> Handle(CreateEquipmentCommand request, CancellationToken cancellationToken)
        {
            var equipment = await _equipmentRepository.GetByIdAsync(request.EquipmentId);
            if (equipment != null)
            {
                throw new EntityNotFoundException(nameof(Equipment), request.EquipmentId);
            }

            var equipmentClass = await _equipmentClassRepository.GetByIdAsync(request.EquipmentClassId);
            if (equipmentClass == null)
            {
                throw new EntityNotFoundException(nameof(EquipmentClass), request.EquipmentClassId);
            }

            var newEquipment = new Equipment(equipmentId: request.EquipmentId,
                                             equipmentName: request.EquipmentName,
                                             equipmentClassId: request.EquipmentClassId);

            foreach (var property in request.Properties)
            {
                var equipmentProperty = await _equipmentPropertyRepository.GetByIdAsync(property.PropertyId);
                if (equipmentProperty != null)
                {
                    throw new EntityNotFoundException(nameof(EquipmentProperty), property.PropertyId);
                }

                if (!Enum.TryParse<UnitOfMeasure>(property.UnitOfMeasure, out var unitOfMeasure))
                {
                    throw new ArgumentException("Invalid status value", nameof(property.UnitOfMeasure));
                }

                var newEquipmentProperty = new EquipmentProperty(propertyId: property.PropertyId,
                                                                 propertyName: property.PropertyName,
                                                                 propertyValue: property.PropertyValue,
                                                                 unitOfMeasure: unitOfMeasure,
                                                                 equipmentId: property.EquipmentId);

                newEquipment.AddProperty(newEquipmentProperty);

            }

            _equipmentRepository.Create(newEquipment);

            return await _equipmentRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
