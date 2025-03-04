namespace WMS.Application.Commands.MaterialCommands.Materials
{
    public class DeleteMaterialCommandHandler : IRequestHandler<DeleteMaterialCommand,bool>
    {
        private readonly IMaterialRepository _materialRepository;

        public DeleteMaterialCommandHandler(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }

        public async Task<bool> Handle(DeleteMaterialCommand deleteMaterialCommand, CancellationToken cancellationToken)
        {
            var material = await _materialRepository.GetByIdAsync(deleteMaterialCommand.MaterialId);
            if (material == null)
            {
                throw new Exception("Material not found"); 
            }

            _materialRepository.Delete(material);

            return await _materialRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        }



    }
}
