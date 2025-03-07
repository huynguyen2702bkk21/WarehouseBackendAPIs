namespace WMS.Application.Commands.MaterialCommands.Materials
{
    public class DeleteMaterialPropertyCommandHandler : IRequestHandler<DeleteMaterialPropertyCommand,bool>
    {
        private readonly IMaterialPropertyRepository _materialPropertyRepository;

        public DeleteMaterialPropertyCommandHandler(IMaterialPropertyRepository materialPropertyRepository)
        {
            _materialPropertyRepository = materialPropertyRepository;
        }

        public async Task<bool> Handle(DeleteMaterialPropertyCommand request, CancellationToken cancellationToken)
        {
            var materialProperty = await _materialPropertyRepository.GetByIdAsync(request.PropertyId);
            if (materialProperty == null)
            {
                throw new EntityNotFoundException(nameof(MaterialProperty), request.PropertyId);
            }

            _materialPropertyRepository.Delete(materialProperty);

            return await _materialPropertyRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        }
    }
}
