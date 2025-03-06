using WMS.Application.Commands.EquipmentCommands.EquipmentProperties;

namespace WMS.Application.Commands.EquipmentCommands.Equipments
{
    public class CreateEquipmentPropertyCommandHandler : IRequestHandler<CreateEquipmentPropertyCommand, bool>
    {
        private readonly IEquipmentPropertyRepository _equipmentPropertyRepository;
        private readonly IEquipmentRepository _equipmentRepository;

        public CreateEquipmentPropertyCommandHandler(IEquipmentPropertyRepository equipmentPropertyRepository, IEquipmentRepository equipmentRepository)
        {
            _equipmentPropertyRepository = equipmentPropertyRepository;
            _equipmentRepository = equipmentRepository;
        }

        public async Task<bool> Handle(CreateEquipmentPropertyCommand request, CancellationToken cancellationToken)
        {
            var equipmentProperty = await _equipmentPropertyRepository.GetByIdAsync(request.PropertyId);
            if (equipmentProperty != null)
            {
                throw new Exception("Equipment property already exists");
            }

            var equipment = await _equipmentRepository.GetByIdAsync(request.EquipmentId);
            if (equipment == null)
            {
                throw new EntityNotFoundException(nameof(Equipment), request.EquipmentId);
            }

            if (!Enum.TryParse<UnitOfMeasure>(request.UnitOfMeasure, out var unitOfMeasure))
            {
                throw new ArgumentException("Invalid status value", nameof(request.UnitOfMeasure));
            }

            var newEquipmentProperty = new EquipmentProperty(propertyId: request.PropertyId,
                                                             propertyName: request.PropertyName,
                                                             propertyValue: request.PropertyValue,
                                                             unitOfMeasure: unitOfMeasure,
                                                             equipmentId: request.EquipmentId);

            _equipmentPropertyRepository.Create(newEquipmentProperty);

            return await _equipmentPropertyRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }

    }
}
    