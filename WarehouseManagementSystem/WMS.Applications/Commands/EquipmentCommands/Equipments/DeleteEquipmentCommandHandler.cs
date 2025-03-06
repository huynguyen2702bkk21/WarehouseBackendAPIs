namespace WMS.Application.Commands.EquipmentCommands.Equipments
{
    public class DeleteEquipmentCommandHandler : IRequestHandler<DeleteEquipmentCommand, bool>
    {
        private readonly IEquipmentRepository _equipmentRepository;

        public DeleteEquipmentCommandHandler(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        public async Task<bool> Handle(DeleteEquipmentCommand request, CancellationToken cancellationToken)
        {
            var equipment = await _equipmentRepository.GetByIdAsync(request.EquipmentId);
            if (equipment == null)
            {
                throw new EntityNotFoundException(nameof(Equipment), request.EquipmentId);
            }

            _equipmentRepository.Delete(equipment);


            return await _equipmentRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);


        }
    }
}
