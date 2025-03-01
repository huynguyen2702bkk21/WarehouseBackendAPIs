namespace WMS.Application.Queries.StorageQueries.Locations
{
    public class GetLocationByIdQueryHandler : IRequestHandler<GetLocationByIdQuery,LocationDTO>
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IMaterialSubLotRepository _materialSubLotRepository;
        private readonly IMapper _mapper;

        public GetLocationByIdQueryHandler(ILocationRepository locationRepository, IWarehouseRepository warehouseRepository, IMaterialSubLotRepository materialSubLotRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _warehouseRepository = warehouseRepository;
            _materialSubLotRepository = materialSubLotRepository;
            _mapper = mapper;
        }

        public async Task<LocationDTO> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
        {
            var location = await _locationRepository.GetLocationByIdAsync(request.Id);
            if (location == null)
            {
                throw new EntityNotFoundException("Locations", request.Id);
            }

            var warehouse = await _warehouseRepository.GetWarehouseByIdAsync(location.warehouseId); 

            var locationDTO = _mapper.Map<LocationDTO>(location);
            locationDTO.MapName(warehouse.warehouseName);

            return locationDTO;


        }


    }
}
