namespace WMS.Application.Commands.EquipmentCommands.EquipmentClassProperties
{
    public class DeleteEquipmentClassPropertyCommandHandler : IRequestHandler<DeleteEquipmentClassPropertyCommand, bool>
    {
        private readonly IEquipmentCLassPropertyRepository _equipmentClassPropertyRepository;

        public DeleteEquipmentClassPropertyCommandHandler(IEquipmentCLassPropertyRepository equipmentClassPropertyRepository)
        {
            _equipmentClassPropertyRepository = equipmentClassPropertyRepository;
        }

        public async Task<bool> Handle(DeleteEquipmentClassPropertyCommand request, CancellationToken cancellationToken)
        {
            var equipmentClassProperty = await _equipmentClassPropertyRepository.GetByIdAsync(request.ClassPropertyId);
            if (equipmentClassProperty == null)
            {
                throw new EntityNotFoundException(nameof(EquipmentClassProperty), request.ClassPropertyId);
            }

            _equipmentClassPropertyRepository.Delete(equipmentClassProperty);

            return await _equipmentClassPropertyRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
