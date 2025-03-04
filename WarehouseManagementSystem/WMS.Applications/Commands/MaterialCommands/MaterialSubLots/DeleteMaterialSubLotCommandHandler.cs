namespace WMS.Application.Commands.MaterialCommands.MaterialSubLots
{
    public class DeleteMaterialSubLotCommandHandler : IRequestHandler<DeleteMaterialSubLotCommand,bool>
    {
        private readonly IMaterialSubLotRepository _materialSubLotRepository;

        public DeleteMaterialSubLotCommandHandler(IMaterialSubLotRepository materialSubLotRepository)
        {
            _materialSubLotRepository = materialSubLotRepository;
        }

        public async Task<bool> Handle(DeleteMaterialSubLotCommand request, CancellationToken cancellationToken)
        {
            var materialSubLot = await _materialSubLotRepository.GetByIdAsync(request.SubLotId);
            if (materialSubLot == null)
            {
                throw new EntityNotFoundException(nameof(MaterialSubLot), request.SubLotId);
            }

            _materialSubLotRepository.Delete(materialSubLot);

            return await _materialSubLotRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }

    }
}
