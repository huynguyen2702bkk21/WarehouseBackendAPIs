namespace WMS.Application.Commands.MaterialCommands.Materials
{
    public class DeleteMaterialCommandHandler : IRequestHandler<DeleteMaterialCommand,bool>
    {
        private readonly IMaterialRepository _materialRepository;

        public DeleteMaterialCommandHandler(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }

        public async Task<bool> Handle(DeleteMaterialCommand request, CancellationToken cancellationToken)
        {
            var material = await _materialRepository.GetByIdAsync(request.MaterialId);
            if (material == null)
            {
                throw new EntityNotFoundException(nameof(Material), request.MaterialId);
            }

            _materialRepository.Delete(material);

            return await _materialRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        }



    }
}
