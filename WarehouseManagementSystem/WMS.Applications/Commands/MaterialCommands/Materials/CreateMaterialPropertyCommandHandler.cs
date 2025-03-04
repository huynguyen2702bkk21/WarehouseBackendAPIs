namespace WMS.Application.Commands.MaterialCommands.Materials
{
    public class CreateMaterialPropertyCommandHandler : IRequestHandler<CreateMaterialPropertyCommand,bool>
    {
        private readonly IMaterialPropertyRepository _materialPropertyRepository;
        private readonly IMapper _mapper;

        public CreateMaterialPropertyCommandHandler(IMaterialPropertyRepository materialPropertyRepository, IMapper mapper)
        {
            _materialPropertyRepository = materialPropertyRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateMaterialPropertyCommand request, CancellationToken cancellationToken)
        {
            var materialProperty = await _materialPropertyRepository.GetByIdAsync(request.PropertyId);
            if (materialProperty != null)
            {
                throw new Exception("Material property already exists");
            }

            if (!Enum.TryParse<UnitOfMeasure>(request.UnitOfMeasure, out var unit))
            {
                throw new ArgumentException("Invalid status value", nameof(request.UnitOfMeasure));
            }

            var newMaterialProperty = new MaterialProperty(propertyId: request.PropertyId,
                                                                     propertyName: request.PropertyName,
                                                                     propertyValue: request.PropertyValue,
                                                                     unitOfMeasure: unit,
                                                                     materialId: request.MaterialId);

            _materialPropertyRepository.Create(newMaterialProperty);

            return await _materialPropertyRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        }

    }
}
