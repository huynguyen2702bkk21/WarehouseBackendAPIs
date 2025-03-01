namespace WMS.Application.Commands.MaterialCommands.MaterialClasses
{
    public class DeleteMaterialClassPropertyCommandHandler : IRequestHandler<DeleteMaterialClassPropertyCommand,bool>
    {
        private readonly IMaterialClassPropertyRepository _materialClassPropertyRepository;
        private readonly IMediator _mediator;

        public DeleteMaterialClassPropertyCommandHandler(IMaterialClassPropertyRepository materialClassPropertyRepository, IMediator mediator)
        {
            _materialClassPropertyRepository = materialClassPropertyRepository;
            _mediator = mediator;
        }

        public async Task<bool> Handle(DeleteMaterialClassPropertyCommand request, CancellationToken cancellationToken)
        {
            var materialClass = await _materialClassPropertyRepository.GetByIdAsync(request.MaterialClassId);
            if (materialClass == null)
            {
                throw new Exception("Material class not found");
            }

            _materialClassPropertyRepository.Delete(materialClass);

            return await _materialClassPropertyRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
    