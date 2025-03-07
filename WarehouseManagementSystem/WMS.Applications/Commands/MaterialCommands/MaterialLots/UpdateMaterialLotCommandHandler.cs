using System.Security.Cryptography.X509Certificates;

namespace WMS.Application.Commands.MaterialCommands.MaterialLots
{
    public class UpdateMaterialLotCommandHandler : IRequestHandler<UpdateMaterialLotCommand,bool>
    {
        private readonly IMaterialLotRepository _materialLotRepository;
        private readonly IMaterialLotPropertyRepository _materialLotPropertyRepository;
        private readonly IMaterialSubLotRepository _materialSubLotRepository;

        public UpdateMaterialLotCommandHandler(IMaterialLotRepository materialLotRepository, IMaterialLotPropertyRepository materialLotPropertyRepository, IMaterialSubLotRepository materialSubLotRepository)
        {
            _materialLotRepository = materialLotRepository;
            _materialLotPropertyRepository = materialLotPropertyRepository;
            _materialSubLotRepository = materialSubLotRepository;
        }

        public async Task<bool> Handle(UpdateMaterialLotCommand request, CancellationToken cancellationToken)
        {
            var materialLot = await _materialLotRepository.GetMaterialLotById(request.LotNumber);
            if (materialLot == null)
            {
                throw new EntityNotFoundException(nameof(MaterialLot), request.LotNumber);
            }

            if (!Enum.TryParse<LotStatus>(request.LotStatus, out var lotStatus))
            {
                throw new Exception("Invalid lot status");
            }

            materialLot.Update(LotStatus: lotStatus,
                               ExisitingQuantity: request.ExisitingQuantity);

            foreach (var property in request.Properties)
            {
                var materialProperty = await _materialLotPropertyRepository.GetMaterialLotPropertyById(property.PropertyId);
                if (materialProperty == null)
                {
                    throw new EntityNotFoundException(nameof(MaterialLotProperty), property.PropertyId);
                }

                if (!Enum.TryParse<UnitOfMeasure>(property.UnitOfMeasure, out var unitProperty))
                {
                    throw new Exception("Invalid lot status");
                }

                materialProperty.Update(PropertyName: property.PropertyName,
                                        PropertyValue: property.PropertyValue,
                                        UnitOfMeasure: unitProperty);

            }

            foreach (var subLot in request.SubLots)
            {
                var materialSubLot = await _materialSubLotRepository.GetByIdAsync(subLot.SubLotId);
                if (materialSubLot == null)
                {
                    throw new EntityNotFoundException(nameof(MaterialSubLot), subLot.SubLotId);
                }

                if (!Enum.TryParse<UnitOfMeasure>(subLot.UnitOfMeasure, out var subUnit))
                {
                    throw new Exception("Invalid lot status");
                }

                if (!Enum.TryParse<LotStatus>(subLot.SubLotStatus, out var subStatus))
                {
                    throw new Exception("Invalid lot status");
                }

                materialSubLot.Update(subLotStatus: subStatus,
                                      existingQuality: subLot.ExistingQuality,
                                      unitOfMeasure: subUnit,
                                      locationId: subLot.LocationId,
                                      lotNumber: subLot.LotNumber);

            }

            return await _materialLotRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);


        }

    }
}
