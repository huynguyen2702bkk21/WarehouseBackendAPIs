    namespace WMS.Application.Commands.MaterialCommands.MaterialClasses
{
    public class CreateMaterialClassPropertyCommandHandler : IRequestHandler<CreateMaterialClassPropertyCommand,bool>
    {
        private readonly IMaterialClassPropertyRepository _materialClassPropertyRepository;
        private readonly IMapper _mapper;

        public CreateMaterialClassPropertyCommandHandler(IMaterialClassPropertyRepository materialClassPropertyRepository, IMapper mapper)
        {
            _materialClassPropertyRepository = materialClassPropertyRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateMaterialClassPropertyCommand request, CancellationToken cancellationToken)
        {
            var materialClassProperty = await _materialClassPropertyRepository.GetByIdAsync(request.PropertyId);
            if (materialClassProperty != null)
            {
                throw new DuplicateRecordException(nameof(MaterialClassProperty),request.PropertyId);
            }

            if (!Enum.TryParse<UnitOfMeasure>(request.UnitOfMeasure, out var unit))
            {
                throw new ArgumentException("Invalid status value", nameof(request.UnitOfMeasure));
            }

            var newMaterialClassProperty = new MaterialClassProperty(propertyId: request.PropertyId,
                                                                     propertyName: request.PropertyName,
                                                                     propertyValue: request.PropertyValue,
                                                                     unitOfMeasure: unit,
                                                                     materialClassId: request.MaterialClassId);

            _materialClassPropertyRepository.Create(newMaterialClassProperty);

            return await _materialClassPropertyRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }



    }
}
