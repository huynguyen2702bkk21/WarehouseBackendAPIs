namespace WMS.Application.Commands.MaterialCommands.MaterialLots
{
    public class CreateMaterialLotCommandHandler : IRequestHandler<CreateMaterialLotCommand,bool>
    { 
        private readonly IMaterialLotRepository _materialLotRepository;
        private readonly IMaterialRepository _materialRepository;
        private readonly IMaterialPropertyRepository _materialPropertyRepository;
        private readonly IMaterialSubLotRepository _materialSubLotRepository;

        public CreateMaterialLotCommandHandler(IMaterialLotRepository materialLotRepository, IMaterialRepository materialRepository, IMaterialPropertyRepository materialPropertyRepository, IMaterialSubLotRepository materialSubLotRepository)
        {
            _materialLotRepository = materialLotRepository;
            _materialRepository = materialRepository;
            _materialPropertyRepository = materialPropertyRepository;
            _materialSubLotRepository = materialSubLotRepository;
        }

        public async Task<bool> Handle(CreateMaterialLotCommand request, CancellationToken cancellationToken)
        {
            var materialLot = await _materialLotRepository.GetMaterialLotById(request.LotNumber);
            if (materialLot != null)
            {
                throw new DuplicateRecordException(nameof(MaterialLot), request.LotNumber);
            }

            if(!Enum.TryParse<LotStatus>(request.LotStatus,out var lotStatus))
            {
                throw new Exception("Invalid lot status");
            }

            var newMaterialLot = new MaterialLot(lotNumber: request.LotNumber,
                                                 lotStatus: lotStatus,
                                                 materialId: request.MaterialId,
                                                 exisitingQuantity: request.ExisitingQuantity);

            foreach (var property in request.Properties)
            {
                var materialProperty = await _materialPropertyRepository.GetByIdAsync(property.PropertyId);
                if (materialProperty != null)
                {
                    throw new DuplicateRecordException(nameof(MaterialProperty), property.PropertyId);
                }

                if (!Enum.TryParse<UnitOfMeasure>(property.UnitOfMeasure, out var unitProperty))
                {
                    throw new Exception("Invalid lot status");
                }

                newMaterialLot.AddProperty(new MaterialLotProperty(propertyId: property.PropertyId,
                                                                   propertyName: property.PropertyName,
                                                                   propertyValue: property.PropertyValue,
                                                                   lotNumber: request.LotNumber,
                                                                   unitOfMeasure: unitProperty));
            }

            foreach (var subLot in request.SubLots) 
            { 
                var materialSubLot = await _materialSubLotRepository.GetByIdAsync(subLot.SubLotId);
                if (materialSubLot != null)
                {
                    throw new DuplicateRecordException(nameof(MaterialSubLot), subLot.SubLotId);
                }

                if (!Enum.TryParse<UnitOfMeasure>(subLot.UnitOfMeasure, out var SubUnit))
                {
                    throw new Exception("Invalid lot status");
                }

                if (!Enum.TryParse<LotStatus>(subLot.SubLotStatus, out var SubLotStatus))
                {
                    throw new Exception("Invalid lot status");
                }

                newMaterialLot.AddSubLot(new MaterialSubLot(subLotId: subLot.SubLotId,
                                                            subLotStatus: SubLotStatus,
                                                            existingQuality: subLot.ExistingQuality,
                                                            unitOfMeasure: SubUnit,
                                                            locationId: subLot.LocationId,
                                                            lotNumber: subLot.LotNumber));
            }

            _materialLotRepository.Create(newMaterialLot);

            return await _materialLotRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        }


    }
}
