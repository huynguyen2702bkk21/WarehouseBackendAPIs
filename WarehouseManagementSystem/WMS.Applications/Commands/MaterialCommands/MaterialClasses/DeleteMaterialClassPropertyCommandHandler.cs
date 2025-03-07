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
            var materialClassProperty = await _materialClassPropertyRepository.GetByIdAsync(request.MaterialClassPropertyId);
            if (materialClassProperty == null)
            {
                throw new EntityNotFoundException(nameof(MaterialClassProperty), request.MaterialClassPropertyId);
            }

            _materialClassPropertyRepository.Delete(materialClassProperty);

            return await _materialClassPropertyRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
    