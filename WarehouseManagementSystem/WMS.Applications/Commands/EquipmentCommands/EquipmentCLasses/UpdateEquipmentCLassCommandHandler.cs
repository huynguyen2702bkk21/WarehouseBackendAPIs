namespace WMS.Application.Commands.EquipmentCommands.EquipmentCLasses
{
    public class UpdateEquipmentCLassCommandHandler : IRequestHandler<UpdateEquipmentCLassCommand, bool>
    {
        private readonly IEquipmentClassRepository _equipmentClassRepository;
        private readonly IEquipmentCLassPropertyRepository _equipmentCLassPropertyRepository;

        public UpdateEquipmentCLassCommandHandler(IEquipmentClassRepository equipmentClassRepository, IEquipmentCLassPropertyRepository equipmentCLassPropertyRepository)
        {
            _equipmentClassRepository = equipmentClassRepository;
            _equipmentCLassPropertyRepository = equipmentCLassPropertyRepository;
        }

        public async Task<bool> Handle(UpdateEquipmentCLassCommand request, CancellationToken cancellationToken)
        {
            var equipmentClass = await _equipmentClassRepository.GetByIdAsync(request.EquipmentClassId);
            if (equipmentClass == null)
            {
                throw new EntityNotFoundException(nameof(EquipmentClass), request.EquipmentClassId);
            }

            equipmentClass.UpdateClassName(request.ClassName);

            foreach (var property in request.Properties)
            {
                var equipmentClassProperty = await _equipmentCLassPropertyRepository.GetByIdAsync(property.PropertyId);
                if (equipmentClassProperty == null)
                {
                    throw new EntityNotFoundException(nameof(EquipmentClassProperty), property.PropertyId);
                }

                if (!Enum.TryParse<UnitOfMeasure>(property.UnitOfMeasure, out var unitOfMeasure))
                {
                    throw new ArgumentException("Invalid status value", nameof(property.UnitOfMeasure));
                }

                equipmentClassProperty.UpdateProperty(property.PropertyName, property.PropertyValue, unitOfMeasure);
            }

            return await _equipmentClassRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
