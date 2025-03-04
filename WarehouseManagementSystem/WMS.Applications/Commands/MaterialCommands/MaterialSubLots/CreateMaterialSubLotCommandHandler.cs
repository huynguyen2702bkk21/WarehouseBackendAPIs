namespace WMS.Application.Commands.MaterialCommands.MaterialSubLots
{
    public class CreateMaterialSubLotCommandHandler : IRequestHandler<CreateMaterialSubLotCommand, bool>
    {
        private readonly IMaterialSubLotRepository _materialSubLotRepository;

        public CreateMaterialSubLotCommandHandler(IMaterialSubLotRepository materialSubLotRepository)
        {
            _materialSubLotRepository = materialSubLotRepository;
        }

        public async Task<bool> Handle(CreateMaterialSubLotCommand request, CancellationToken cancellationToken)
        {
            var materialSubLot = await _materialSubLotRepository.GetByIdAsync(request.SubLotId);
            if (materialSubLot != null)
            {
                throw new Exception("Material sub lot already exists");
            }

            if (!Enum.TryParse<LotStatus>(request.SubLotStatus, out var status))
            {
                throw new ArgumentException("Invalid status value", nameof(request.SubLotStatus));
            }

            if (!Enum.TryParse<UnitOfMeasure>(request.UnitOfMeasure, out var unit))
            {
                throw new ArgumentException("Invalid status value", nameof(request.UnitOfMeasure));
            }


            var newMaterialSubLot = new MaterialSubLot(subLotId: request.SubLotId,
                                                       subLotStatus: status,
                                                       existingQuality: request.ExistingQuality,
                                                       unitOfMeasure: unit,
                                                       locationId: request.LocationId,
                                                       lotNumber: request.LotNumber);

            _materialSubLotRepository.Create(newMaterialSubLot);

            return await _materialSubLotRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);


        }

    }
}
