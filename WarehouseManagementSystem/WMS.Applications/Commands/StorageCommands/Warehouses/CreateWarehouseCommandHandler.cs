namespace WMS.Application.Commands.StorageCommands.Warehouses
{
    public class CreateWarehouseCommandHandler : IRequestHandler<CreateWarehouseCommand, bool>
    {
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IMapper _mapper;

        public CreateWarehouseCommandHandler(IWarehouseRepository warehouseRepository, IMapper mapper)
        {
            _warehouseRepository = warehouseRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateWarehouseCommand request, CancellationToken cancellationToken)
        {
            var warehouse = await _warehouseRepository.GetWarehouseById(request.WarehouseId);
            if(warehouse != null)
            {
                throw new DuplicateRecordException(nameof(Warehouse), request.WarehouseId);
            }

            warehouse = new Warehouse(request.WarehouseId, request.WarehouseName);

            _warehouseRepository.Create(warehouse);

            return await _warehouseRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
