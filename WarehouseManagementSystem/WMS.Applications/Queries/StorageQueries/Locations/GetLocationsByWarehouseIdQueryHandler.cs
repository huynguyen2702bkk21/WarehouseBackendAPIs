namespace WMS.Application.Queries.StorageQueries.Locations
{
    public class GetLocationsByWarehouseIdQueryHandler : IRequestHandler<GetLocationsByWarehouseIdQuery, List<LocationDTO>>
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IMapper _mapper;

        public GetLocationsByWarehouseIdQueryHandler(ILocationRepository locationRepository, IWarehouseRepository warehouseRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _warehouseRepository = warehouseRepository;
            _mapper = mapper;
        }

        public async Task<List<LocationDTO>> Handle(GetLocationsByWarehouseIdQuery request, CancellationToken cancellationToken)
        {
            var locations = await _locationRepository.GetLocationsByWarehouseId(request.WarehouseId);
            if (locations.Count == 0)
            {
                 throw new EntityNotFoundException("Locaitons Not Found");
            }

            List<LocationDTO> locationDTOs = new List<LocationDTO>();

            foreach(var location in locations)
            {
                var warehouse = await _warehouseRepository.GetWarehouseById(location.warehouseId);
                if(warehouse == null)
                {
                    warehouse.warehouseName = "";
                }

                var locationDTO = new LocationDTO(locationId: location.locationId,
                                                  warehouseName: warehouse.warehouseName);

                locationDTOs.Add(locationDTO);
            }

                        
            return locationDTOs;
        }


    }
}
