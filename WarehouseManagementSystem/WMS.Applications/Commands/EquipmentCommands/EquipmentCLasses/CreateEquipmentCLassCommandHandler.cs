namespace WMS.Application.Commands.EquipmentCommands.EquipmentCLasses
{
    public class CreateEquipmentCLassCommandHandler : IRequestHandler<CreateEquipmentCLassCommand,bool>
    {
        private readonly IEquipmentClassRepository _equipmentClassRepository;
        private readonly IEquipmentCLassPropertyRepository _equipmentCLassPropertyRepository;
        private readonly IMediator _mediator;

        public CreateEquipmentCLassCommandHandler(IEquipmentClassRepository equipmentClassRepository, IEquipmentCLassPropertyRepository equipmentCLassPropertyRepository, IMediator mediator)
        {
            _equipmentClassRepository = equipmentClassRepository;
            _equipmentCLassPropertyRepository = equipmentCLassPropertyRepository;
            _mediator = mediator;
        }

        public async Task<bool> Handle(CreateEquipmentCLassCommand request, CancellationToken cancellationToken)
        {
            var equipmentClass = await _equipmentClassRepository.GetByIdAsync(request.EquipmentClassId);
            if (equipmentClass != null)
            {
                throw new Exception("Equipment class already exists");
            }

            var newEquipmentClass = new EquipmentClass(equipmentClassId: request.EquipmentClassId,
                                                       className: request.ClassName);

            foreach (var property in request.Properties)
            {
                var equipmentClassProperty = await _equipmentCLassPropertyRepository.GetByIdAsync(property.PropertyId);
                if (equipmentClassProperty != null)
                {
                    throw new Exception("Equipment class property already exists");
                }

                if (!Enum.TryParse<UnitOfMeasure>(property.UnitOfMeasure, out var unitOfMeasure))
                {
                    throw new ArgumentException("Invalid status value", nameof(property.UnitOfMeasure));
                }

                var newEquipmentClassProperty = new EquipmentClassProperty(propertyId: property.PropertyId,
                                                                          propertyName: property.PropertyName,
                                                                          propertyValue: property.PropertyValue,
                                                                          unitOfMeasure: unitOfMeasure,
                                                                          equipmentClassId: newEquipmentClass.equipmentClassId);

                newEquipmentClass.AddProperty(newEquipmentClassProperty);
            }

            _equipmentClassRepository.Create(newEquipmentClass);

            return await _equipmentClassRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);


        }
    }
}
