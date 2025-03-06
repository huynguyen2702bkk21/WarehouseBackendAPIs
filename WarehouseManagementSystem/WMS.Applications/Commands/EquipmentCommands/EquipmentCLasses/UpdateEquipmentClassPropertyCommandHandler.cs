using WMS.Application.Commands.EquipmentCommands.EquipmentCLasses;

namespace WMS.Application.Commands.EquipmentCommands.EquipmentClassProperties
{
    public class UpdateEquipmentClassPropertyCommandHandler : IRequestHandler<UpdateEquipmentClassPropertyCommand, bool>
    {
        private readonly IEquipmentCLassPropertyRepository _equipmentCLassPropertyRepository;

        public UpdateEquipmentClassPropertyCommandHandler(IEquipmentCLassPropertyRepository equipmentCLassPropertyRepository)
        {
            _equipmentCLassPropertyRepository = equipmentCLassPropertyRepository;
        }

        public async  Task<bool> Handle(UpdateEquipmentClassPropertyCommand request, CancellationToken cancellationToken)
        {
            var equipmentClassProperty = await _equipmentCLassPropertyRepository.GetByIdAsync(request.PropertyId);
            if(equipmentClassProperty == null)
            {
                throw new EntityNotFoundException(nameof(EquipmentClassProperty), request.PropertyId);
            }

            if (!Enum.TryParse<UnitOfMeasure>(request.UnitOfMeasure, out var unitOfMeasure))
            {
                throw new ArgumentException("Invalid status value", nameof(request.UnitOfMeasure));
            }

            equipmentClassProperty.UpdateProperty(request.PropertyName, request.PropertyValue, unitOfMeasure);

            return await _equipmentCLassPropertyRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        }
    }
}
