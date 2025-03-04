namespace WMS.Application.Commands.MaterialCommands.MaterialClasses
{
    public class CreateMaterialClassCommandHandler : IRequestHandler<CreateMaterialClassCommand,bool>
    {
        private readonly IMaterialClassRepository _materialClassRepository;
        private readonly IMaterialClassPropertyRepository _materialClassPropertyRepository;
        private readonly IMapper _mapper;

        public CreateMaterialClassCommandHandler(IMaterialClassRepository materialClassRepository, IMaterialClassPropertyRepository materialClassPropertyRepository, IMapper mapper)
        {
            _materialClassRepository = materialClassRepository;
            _materialClassPropertyRepository = materialClassPropertyRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateMaterialClassCommand request, CancellationToken cancellationToken)
        {
            var material = await _materialClassRepository.GetById(request.MaterialClassId);
            if (material != null)
            {
                throw new Exception("MaterialClass already exists");
            }

            var newMaterialClass = new MaterialClass(materialClassId: request.MaterialClassId,
                                                className: request.ClassName);

            foreach (var property in request.Properties)
            {
                var checkProperty = await _materialClassPropertyRepository.GetByIdAsync(property.PropertyId);
                if (checkProperty != null)
                {
                    throw new Exception("MaterialClass property already exists");
                }

                if (!Enum.TryParse<UnitOfMeasure>(property.UnitOfMeasure, out var unit))
                {
                    throw new ArgumentException("Invalid status value", nameof(property.UnitOfMeasure));
                }

                var newProperty = new MaterialClassProperty (propertyId: property.PropertyId,
                                                             propertyName: property.PropertyName,
                                                             propertyValue: property.PropertyValue,
                                                             unitOfMeasure: unit,
                                                             materialClassId: newMaterialClass.materialClassId);

                newMaterialClass.AddProperty(newProperty);

            }

            _materialClassRepository.Create(newMaterialClass);

            return await _materialClassRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        }
    }
}
