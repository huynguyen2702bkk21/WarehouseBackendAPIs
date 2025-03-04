namespace WMS.Application.Commands.MaterialCommands.Materials
{
    public class DeleteMaterialPropertyCommandHandler : IRequestHandler<DeleteMaterialPropertyCommand,bool>
    {
        private readonly IMaterialPropertyRepository _materialPropertyRepository;

        public DeleteMaterialPropertyCommandHandler(IMaterialPropertyRepository materialPropertyRepository)
        {
            _materialPropertyRepository = materialPropertyRepository;
        }

        public async Task<bool> Handle(DeleteMaterialPropertyCommand deleteMaterialPropertyCommand, CancellationToken cancellationToken)
        {
            var materialProperty = await _materialPropertyRepository.GetByIdAsync(deleteMaterialPropertyCommand.PropertyId);
            if (materialProperty == null)
            {
                throw new Exception("Material Property not found"); 
            }

            _materialPropertyRepository.Delete(materialProperty);

            return await _materialPropertyRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        }
    }
}
