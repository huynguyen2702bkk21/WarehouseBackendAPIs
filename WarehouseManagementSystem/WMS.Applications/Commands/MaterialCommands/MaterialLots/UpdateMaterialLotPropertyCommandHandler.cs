namespace WMS.Application.Commands.MaterialCommands.MaterialLots
{
    public class UpdateMaterialLotPropertyCommandHandler : IRequestHandler<UpdateMaterialLotPropertyCommand,bool>
    {
        private readonly IMaterialLotPropertyRepository _materialLotPropertyRepository;

        public UpdateMaterialLotPropertyCommandHandler(IMaterialLotPropertyRepository materialLotPropertyRepository)
        {
            _materialLotPropertyRepository = materialLotPropertyRepository;
        }

        public async Task<bool> Handle (UpdateMaterialLotPropertyCommand request, CancellationToken cancellationToken)
        {
            var materialLotProperty = await _materialLotPropertyRepository.GetMaterialLotPropertyById(request.PropertyId);
            if (materialLotProperty == null)
            {
                throw new Exception("Material lot property not found");
            }

            if(!Enum.TryParse<UnitOfMeasure>(request.UnitOfMeasure,out var unit))
            {
                throw new Exception("Invalid unit of measure");
            }

            materialLotProperty.Update(PropertyName: request.PropertyName,
                                       PropertyValue: request.PropertyValue,
                                       UnitOfMeasure: unit);

            return await _materialLotPropertyRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }


    }
}

