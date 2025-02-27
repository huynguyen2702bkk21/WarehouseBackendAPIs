namespace WMS.Application.Queries.StorageQueries.Locations
{
    public class GetLocationByIdQueryHandler : IRequestHandler<GetLocationByIdQuery,LocationDTO>
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IMapper _mapper;

        public GetLocationByIdQueryHandler(ILocationRepository locationRepository, IWarehouseRepository warehouseRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _warehouseRepository = warehouseRepository;
            _mapper = mapper;
        }

        public async Task<LocationDTO> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
        {
            var location = await _locationRepository.GetLocationById(request.Id);

            if (location == null)
            {
                throw new EntityNotFoundException("Locations", request.Id);
            }

            var warehouse = await _warehouseRepository.GetWarehouseById(location.warehouseId);

            if (warehouse == null)
            {
                throw new EntityNotFoundException("Warehouses", location.warehouseId);
            }

            LocationDTO locationDTO = new LocationDTO(locationId: location.locationId,
                                                      warehouseName: warehouse.warehouseName);

            return locationDTO;
        }


    }
}
