namespace WMS.Application.Commands.StorageCommands.Locations
{
    public class DeleteLocationCommandHandler  : IRequestHandler<DeleteLocationCommand,bool>
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;

        public DeleteLocationCommandHandler(ILocationRepository locationRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
        {
            var location = await _locationRepository.GetLocationById(request.LocationId);
            if (location == null)
            {
                throw new EntityNotFoundException("Location", request.LocationId);
            }

            _locationRepository.Delete(location);

            return await _locationRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }


    }
}
