namespace WMS.Application.Commands.StorageCommands.Locations
{
    public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand, bool>
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;

        public CreateLocationCommandHandler(ILocationRepository locationRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            var location = await _locationRepository.GetLocationById(request.LocationId);
            if (location != null)
            {
                throw new DuplicateRecordException("Location", request.LocationId);
            }

            var newLocation = new Location(locationId: request.LocationId,
                                        warehouseId: request.WarehouseId);

            _locationRepository.Create(newLocation);

            return await _locationRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }



    }
}
