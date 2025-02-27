namespace WMS.Application.Queries.StorageQueries.Warehouses
{
    public class GetWarehouseByIdQueryHandler : IRequestHandler<GetWarehouseByIdQuery, WarehouseDTO>
    {
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IMapper _mapper;

        public GetWarehouseByIdQueryHandler(IWarehouseRepository warehouseRepository, IMapper mapper)
        {
            _warehouseRepository = warehouseRepository;
            _mapper = mapper;
        }

        public async Task<WarehouseDTO> Handle(GetWarehouseByIdQuery request, CancellationToken cancellationToken)
        {
            var warehouse = await _warehouseRepository.GetWarehouseById(request.WarehouseId);

            if (warehouse == null)
            {
                throw new EntityNotFoundException("Warehouses", request.WarehouseId);
            }

            var warehouseDTO =  _mapper.Map<WarehouseDTO>(warehouse);

            return warehouseDTO;
        }

    }
}
