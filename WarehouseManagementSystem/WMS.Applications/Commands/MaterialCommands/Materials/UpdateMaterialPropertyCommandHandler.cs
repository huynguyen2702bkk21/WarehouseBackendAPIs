namespace WMS.Application.Commands.MaterialCommands.Materials
{
    public class UpdateMaterialPropertyCommandHandler : IRequestHandler<UpdateMaterialPropertyCommand, bool>
    {
        private readonly IMaterialPropertyRepository _materialPropertyRepository;

        public UpdateMaterialPropertyCommandHandler(IMaterialPropertyRepository materialPropertyRepository)
        {
            _materialPropertyRepository = materialPropertyRepository;
        }

        public async Task<bool> Handle(UpdateMaterialPropertyCommand request, CancellationToken cancellationToken)
        {
            var materialProperty = await _materialPropertyRepository.GetByIdAsync(request.PropertyId);
            if (materialProperty == null)
            {
                throw new EntityNotFoundException(nameof(MaterialProperty), request.PropertyId);
            }

            if (!Enum.TryParse<UnitOfMeasure>(request.UnitOfMeasure, out var unit))
            {
                throw new ArgumentException("Invalid status value", nameof(request.UnitOfMeasure));
            }

            materialProperty.Update(request.PropertyName, request.PropertyValue, unit);

            return await _materialPropertyRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);


        }
    }
}
