namespace WMS.Application.Commands.EquipmentCommands.Equipments
{
    public class UpdateEquipmentCommandHandler : IRequestHandler<UpdateEquipmentCommand,bool>
    {
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IEquipmentPropertyRepository _equipmentPropertyRepository;

        public UpdateEquipmentCommandHandler(IEquipmentRepository equipmentRepository, IEquipmentPropertyRepository equipmentPropertyRepository, IEquipmentClassRepository equipmentClassRepository)
        {
            _equipmentRepository = equipmentRepository;
            _equipmentPropertyRepository = equipmentPropertyRepository;
            _equipmentClassRepository = equipmentClassRepository;
        }

        private readonly IEquipmentClassRepository _equipmentClassRepository;

        public async Task<bool> Handle(UpdateEquipmentCommand request, CancellationToken cancellationToken)
        {
            var equipment = await _equipmentRepository.GetByIdAsync(request.EquipmentId);
            if(equipment == null)
            {
                throw new EntityNotFoundException(nameof(Equipment), request.EquipmentId);
            }

            var equipmentClass = await _equipmentClassRepository.GetByIdAsync(request.EquipmentClassId);
            if(equipmentClass == null)
            {
                throw new EntityNotFoundException(nameof(EquipmentClass), request.EquipmentClassId);
            }

            equipment.UpdateEquipment(request.EquipmentName, request.EquipmentClassId);

            foreach(var property in request.Properties)
            {
                var equipmentProperty = await _equipmentPropertyRepository.GetByIdAsync(property.PropertyId);
                if(equipmentProperty == null)
                {
                    throw new EntityNotFoundException(nameof(EquipmentProperty), property.PropertyId);
                }

                if (!Enum.TryParse<UnitOfMeasure>(property.UnitOfMeasure, out var unitOfMeasure))
                {
                    throw new ArgumentException("Invalid status value", nameof(property.UnitOfMeasure));
                }

                equipmentProperty.UpdateEquipmentProperty(property.PropertyName, property.PropertyValue, unitOfMeasure);
            }

            return await _equipmentRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }


    }
}
