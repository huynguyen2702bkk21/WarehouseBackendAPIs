namespace WMS.Application.Commands.MaterialCommands.MaterialLots
{
    public class DeleteMaterialLotCommandHandler : IRequestHandler<DeleteMaterialLotCommand,bool>
    {
        private readonly IMaterialLotRepository _materialLotRepository;

        public DeleteMaterialLotCommandHandler(IMaterialLotRepository materialLotRepository)
        {
            _materialLotRepository = materialLotRepository;
        }

        public async Task<bool> Handle(DeleteMaterialLotCommand request, CancellationToken cancellationToken)
        {
            var materialLot = await _materialLotRepository.GetMaterialLotById(request.LotNumber);
            if (materialLot == null)
            {
                throw new EntityNotFoundException(nameof(MaterialLot), request.LotNumber);
            }

            _materialLotRepository.Delete(materialLot);

            return await _materialLotRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
