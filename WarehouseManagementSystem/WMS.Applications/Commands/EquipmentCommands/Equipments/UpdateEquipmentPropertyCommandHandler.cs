namespace WMS.Application.Commands.EquipmentCommands.Equipments
{
    public class UpdateEquipmentPropertyCommandHandler : IRequestHandler<UpdateEquipmentPropertyCommand, bool>
    {
        private readonly IEquipmentPropertyRepository _equipmentPropertyRepository;

        public UpdateEquipmentPropertyCommandHandler(IEquipmentPropertyRepository equipmentPropertyRepository)
        {
            _equipmentPropertyRepository = equipmentPropertyRepository;
        }

        public async  Task<bool> Handle(UpdateEquipmentPropertyCommand request, CancellationToken cancellationToken)
        {
            var equipmentProperty = await _equipmentPropertyRepository.GetByIdAsync(request.PropertyId);
            if(equipmentProperty == null)
            {
               throw new EntityNotFoundException(nameof(EquipmentProperty), request.PropertyId);
            }

            if (!Enum.TryParse<UnitOfMeasure>(request.UnitOfMeasure, out var unitOfMeasure))
            {
                throw new ArgumentException("Invalid status value", nameof(request.UnitOfMeasure));
            }

            equipmentProperty.UpdateEquipmentProperty(request.PropertyName, request.PropertyValue, unitOfMeasure);

            return await _equipmentPropertyRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
