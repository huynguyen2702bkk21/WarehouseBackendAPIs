namespace WMS.Application.Commands.MaterialCommands.MaterialSubLots
{
    public class UpdateMaterialSubLotCommandHandler : IRequestHandler<UpdateMaterialSubLotCommand,bool>
    {
        private readonly IMaterialSubLotRepository _materialSubLotRepository;

        public UpdateMaterialSubLotCommandHandler(IMaterialSubLotRepository materialSubLotRepository)
        {
            _materialSubLotRepository = materialSubLotRepository;
        }

        public async Task<bool> Handle(UpdateMaterialSubLotCommand request, CancellationToken cancellationToken)
        {
            var materialSubLot = await _materialSubLotRepository.GetByIdAsync(request.SubLotId);
            if (materialSubLot == null)
            {
                throw new EntityNotFoundException(nameof(MaterialSubLot), request.SubLotId);
            }

            if (!Enum.TryParse<LotStatus>(request.SubLotStatus, out var status))
            {
                throw new ArgumentException("Invalid status value", nameof(request.SubLotStatus));
            }

            if (!Enum.TryParse<UnitOfMeasure>(request.UnitOfMeasure, out var unit))
            {
                throw new ArgumentException("Invalid status value", nameof(request.UnitOfMeasure));
            }

            materialSubLot.Update(subLotStatus: status,
                                  existingQuality: request.ExistingQuality,
                                  unitOfMeasure: unit,
                                  locationId: request.LocationId,
                                  lotNumber: request.LotNumber);

            return await _materialSubLotRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        }


    }
}
