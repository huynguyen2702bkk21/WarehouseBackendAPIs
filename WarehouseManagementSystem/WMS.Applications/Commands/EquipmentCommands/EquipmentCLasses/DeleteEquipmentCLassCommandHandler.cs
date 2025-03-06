namespace WMS.Application.Commands.EquipmentCommands.EquipmentCLasses
{
    public class DeleteEquipmentCLassCommandHandler : IRequestHandler<DeleteEquipmentCLassCommand, bool>
    {
        private readonly IEquipmentClassRepository _equipmentClassRepository;

        public DeleteEquipmentCLassCommandHandler(IEquipmentClassRepository equipmentClassRepository)
        {
            _equipmentClassRepository = equipmentClassRepository;
        }

        public async Task<bool> Handle(DeleteEquipmentCLassCommand request, CancellationToken cancellationToken)
        {
            var equipmentClass = await _equipmentClassRepository.GetByIdAsync(request.EquipmentClassId);
            if (equipmentClass == null)
            {
                throw new EntityNotFoundException(nameof(EquipmentClass), request.EquipmentClassId);
            }

            _equipmentClassRepository.Delete(equipmentClass);

            return await _equipmentClassRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);


        }
    }
}
