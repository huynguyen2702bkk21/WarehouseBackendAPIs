namespace WMS.Application.Commands.MaterialCommands.MaterialLots
{
    public class DeleteMaterialLotPropertyCommandHandler : IRequestHandler<DeleteMaterialLotPropertyCommand, bool>
    {
        private readonly IMaterialLotPropertyRepository _materialLotPropertyRepository;

        public DeleteMaterialLotPropertyCommandHandler(IMaterialLotPropertyRepository materialLotPropertyRepository)
        {
            _materialLotPropertyRepository = materialLotPropertyRepository;
        }

        public async Task<bool> Handle(DeleteMaterialLotPropertyCommand request, CancellationToken cancellationToken) 
        {
            var materialLotProperty = await _materialLotPropertyRepository.GetMaterialLotPropertyById(request.PropertyId);
            if (materialLotProperty == null)
            {
                throw new EntityNotFoundException(nameof(MaterialLotProperty), request.PropertyId);
            }

            _materialLotPropertyRepository.Delete(materialLotProperty);

            return await _materialLotPropertyRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }

    }
}
