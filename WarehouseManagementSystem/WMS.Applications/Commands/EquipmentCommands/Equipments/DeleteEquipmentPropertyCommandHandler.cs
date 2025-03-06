namespace WMS.Application.Commands.EquipmentCommands.Equipments
{
    public class DeleteEquipmentPropertyCommandHandler : IRequestHandler<DeleteEquipmentPropertyCommand, bool>
    {
        private readonly IEquipmentPropertyRepository _equipmentPropertyRepository;

        public DeleteEquipmentPropertyCommandHandler(IEquipmentPropertyRepository equipmentPropertyRepository)
        {
            _equipmentPropertyRepository = equipmentPropertyRepository;
        }

        public async Task<bool> Handle(DeleteEquipmentPropertyCommand request, CancellationToken cancellationToken)
        {
            var equipmentProperty = await _equipmentPropertyRepository.GetByIdAsync(request.EquipmentPropertyId);
            if (equipmentProperty == null)
            {
                throw new EntityNotFoundException(nameof(EquipmentProperty), request.EquipmentPropertyId);
            }

            _equipmentPropertyRepository.Delete(equipmentProperty);

            return await _equipmentPropertyRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }




    }
}
