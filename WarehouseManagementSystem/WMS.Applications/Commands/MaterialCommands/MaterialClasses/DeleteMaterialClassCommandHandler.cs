namespace WMS.Application.Commands.MaterialCommands.MaterialClasses
{
    public class DeleteMaterialClassCommandHandler : IRequestHandler<DeleteMaterialClassCommand,bool>
    {
        private readonly IMaterialClassRepository _materialClassRepository;
        private readonly IMediator _mediator;

        public DeleteMaterialClassCommandHandler(IMaterialClassRepository materialClassRepository, IMediator mediator)
        {
            _materialClassRepository = materialClassRepository;
            _mediator = mediator;
        }

        public async Task<bool> Handle(DeleteMaterialClassCommand request, CancellationToken cancellationToken)
        {
            var materialClass = await _materialClassRepository.GetByIdAsync(request.MaterialClassId);
            if (materialClass == null)
            {
                throw new EntityNotFoundException(nameof(MaterialClass), request.MaterialClassId);
            }

            _materialClassRepository.Delete(materialClass);

            return await _materialClassRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }




    }
}
