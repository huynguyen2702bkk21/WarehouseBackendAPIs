namespace WMS.Application.Commands.MaterialCommands.MaterialLots
{
    public class CreateMaterialLotPropertyCommandHandler : IRequestHandler<CreateMaterialLotPropertyCommand, bool>
    {
        private readonly IMaterialLotPropertyRepository _materialLotPropertyRepository;

        public CreateMaterialLotPropertyCommandHandler(IMaterialLotPropertyRepository materialLotPropertyRepository)
        {
            _materialLotPropertyRepository = materialLotPropertyRepository;
        }

        public async Task<bool> Handle(CreateMaterialLotPropertyCommand request, CancellationToken cancellationToken)
        {
            var materialLotProperty = await _materialLotPropertyRepository.GetMaterialLotPropertyById(request.PropertyId);
            if (materialLotProperty != null)
            {
                throw new Exception("Material lot property already exists");
            }

            if(!Enum.TryParse<UnitOfMeasure>(request.UnitOfMeasure,out var unit))
            {
                throw new Exception("Invalid unit of measure");
            }

            var newMaterialLotProperty = new MaterialLotProperty(propertyId:request.PropertyId,
                                                                 propertyName: request.PropertyName,
                                                                 propertyValue: request.PropertyValue,
                                                                 lotNumber: request.MaterialLotId,
                                                                 unitOfMeasure: unit);

            _materialLotPropertyRepository.Create(newMaterialLotProperty);

            return await _materialLotPropertyRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }

    }
}
