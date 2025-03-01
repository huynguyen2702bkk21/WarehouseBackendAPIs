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
            var materialCLass = await _materialClassRepository.GetById(request.MaterialClassId);
            if (materialCLass != null)
            {
                throw new Exception("Material class already exists");
            }

            var property = await _materialClassPropertyRepository.GetByIdAsync(request.PropertyDTO.PropertyId);
            if(property != null)
            {
                throw new Exception("Material class property already exists");
            }

            var newMaterialClass = new MaterialClass(request.MaterialClassId, request.ClassName);
            
            var newproperty = new MaterialClassProperty(propertyId: request.PropertyDTO.PropertyId,
                                                        propertyName: request.PropertyDTO.PropertyName,
                                                        propertyValue: request.PropertyDTO.PropertyValue,
                                                        unitOfMeasure: request.PropertyDTO.UnitOfMeasure,
                                                        materialClassId: newMaterialClass.materialClassId);

            newMaterialClass.AddProperty(newproperty);
            
            _materialClassRepository.Create(newMaterialClass);

            return await _materialClassRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        }
    }
}
