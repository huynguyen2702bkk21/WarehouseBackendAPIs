namespace WMS.Application.Queries.StorageQueries.Locations
{
    public class GetAllLocationQueryHandler : IRequestHandler<GetAllLocationQuery, List<LocationDTO>>
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IMapper _mapper;

        public GetAllLocationQueryHandler(ILocationRepository locationRepository, IWarehouseRepository warehouseRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _warehouseRepository = warehouseRepository;
            _mapper = mapper;
        }

        public async Task<List<LocationDTO>> Handle(GetAllLocationQuery request, CancellationToken cancellationToken)
        {
            var locations = await _locationRepository.GetAllLocations();
            if(locations == null)
            {
                return null;
            }

            List<LocationDTO> locationDTOs = new List<LocationDTO>();


            foreach (var location in locations)
            {
                var Warehouse = await _warehouseRepository.GetWarehouseById(location.warehouseId);
                if (Warehouse == null)
                {
                    Warehouse.warehouseName = "";
                }

                LocationDTO locationDTO = new LocationDTO(locationId: location.locationId,
                                                          warehouseName: Warehouse.warehouseName);

                locationDTOs.Add(locationDTO);

            }

            return locationDTOs;

        }
    }
}
