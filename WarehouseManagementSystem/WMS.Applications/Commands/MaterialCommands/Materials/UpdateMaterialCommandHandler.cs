namespace WMS.Application.Commands.MaterialCommands.Materials
{
    public class UpdateMaterialCommandHandler : IRequestHandler<UpdateMaterialCommand,bool>
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IMaterialPropertyRepository _materialPropertyRepository;

        public UpdateMaterialCommandHandler(IMaterialRepository materialRepository, IMaterialPropertyRepository materialPropertyRepository)
        {
            _materialRepository = materialRepository;
            _materialPropertyRepository = materialPropertyRepository;
        }

        public async Task<bool> Handle(UpdateMaterialCommand request, CancellationToken cancellationToken)
        {
            var material = await _materialRepository.GetByIdAsync(request.MaterialId);
            if (material == null)
            {
                throw new EntityNotFoundException(nameof(Material), request.MaterialId);
            }

            foreach (var materialProperty in request.Properties)
            {
                var materialPropertyEntity = await _materialPropertyRepository.GetByIdAsync(materialProperty.PropertyId);
                if (materialPropertyEntity == null)
                {
                    throw new EntityNotFoundException(nameof(MaterialProperty), materialProperty.PropertyId);
                }

                if(!Enum.TryParse<UnitOfMeasure>(materialProperty.UnitOfMeasure, out var unit))
                {
                    throw new ArgumentException("Invalid status value", nameof(materialProperty.UnitOfMeasure));
                }

                materialPropertyEntity.Update(PropertyName: materialProperty.PropertyName,
                                              PropertyValue: materialProperty.PropertyValue,
                                              UnitOfMeasure: unit);
            }

            material.Update(MaterialName: request.MaterialName,
                            MaterialClassId: request.MaterialClassId);

            return await _materialRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }


    }
}
