namespace WMS.Application.Commands.StorageCommands.Locations
{
    public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand,bool>
    {
        private readonly ILocationRepository _locationRepository; 
        private readonly IMapper _mapper;

        public UpdateLocationCommandHandler(ILocationRepository locationRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {
            var location = await _locationRepository.GetLocationById(request.LocationId);
            if (location == null)
            {
                throw new EntityNotFoundException(nameof(Location), request.LocationId);
            }

            location.UpdateLocation(request.WarehouseId);

            return await _locationRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
