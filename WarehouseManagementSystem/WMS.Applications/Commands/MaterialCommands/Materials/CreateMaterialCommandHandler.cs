namespace WMS.Application.Commands.MaterialCommands.Materials
{
    public class CreateMaterialCommandHandler : IRequestHandler<CreateMaterialCommand,bool>
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IMaterialPropertyRepository _materialPropertyRepository;
        private readonly IMapper _mapper;

        public CreateMaterialCommandHandler(IMaterialRepository materialRepository, IMaterialPropertyRepository materialPropertyRepository, IMapper mapper)
        {
            _materialRepository = materialRepository;
            _materialPropertyRepository = materialPropertyRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateMaterialCommand request, CancellationToken cancellationToken)
        {
            var material = await _materialRepository.GetById(request.MaterialId);
            if (material != null)
            {
                throw new Exception("Material already exists");
            }

            var newMaterial = new Material(materialId: request.MaterialId,
                                           materialName: request.MaterialName,
                                           materialClassId: request.MaterialClassId);

            foreach (var property in request.Properties)
            {
                var checkProperty = await _materialPropertyRepository.GetByIdAsync(property.PropertyId); 
                if(checkProperty != null)
                {
                    throw new Exception("Material property already exists");
                }

                if(!Enum.TryParse<UnitOfMeasure>(property.UnitOfMeasure, out var unit))
                {
                    throw new ArgumentException("Invalid status value", nameof(property.UnitOfMeasure));
                }

                var newProperty = new MaterialProperty(propertyId: property.PropertyId,
                                                       propertyName: property.PropertyName,
                                                       propertyValue: property.PropertyValue,
                                                       unitOfMeasure: unit,
                                                       materialId: newMaterial.materialId);

                newMaterial.AddProperty(newProperty);

            }
            
            _materialRepository.Create(newMaterial);

            return await _materialRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
                
        }


    }
}
