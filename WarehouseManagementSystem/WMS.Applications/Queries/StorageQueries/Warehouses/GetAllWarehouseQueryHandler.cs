namespace WMS.Application.Queries.StorageQueries.Warehouses
{
    public class GetAllWarehouseQueryHandler : IRequestHandler<GetAllWarehouseQuery, IEnumerable<WarehouseDTO>>
    {
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IMapper _mapper;

        public GetAllWarehouseQueryHandler(IWarehouseRepository warehouseRepository, IMapper mapper)
        {
            _warehouseRepository = warehouseRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<WarehouseDTO>> Handle(GetAllWarehouseQuery request, CancellationToken cancellationToken)
        {
            var warehouses = await _warehouseRepository.GetAllWarehouses();

            if (warehouses == null)
            {
                return null;
            }

            var warehouseDTOs =  _mapper.Map<IEnumerable<WarehouseDTO>>(warehouses);

            return warehouseDTOs;
        }




    }
}
