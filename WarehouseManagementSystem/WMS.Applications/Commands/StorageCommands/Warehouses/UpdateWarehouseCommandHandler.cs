namespace WMS.Application.Commands.StorageCommands.Warehouses
{
    public class UpdateWarehouseCommandHandler : IRequestHandler<UpdateWarehouseCommand, bool>
    {
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IMapper _mapper;

        public UpdateWarehouseCommandHandler(IWarehouseRepository warehouseRepository, IMapper mapper)
        {
            _warehouseRepository = warehouseRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateWarehouseCommand request, CancellationToken cancellationToken)
        {
            var warehouse = await _warehouseRepository.GetWarehouseById(request.WarehouseId);
            if (warehouse == null)
            {
                throw new EntityNotFoundException(nameof(Warehouse), request.WarehouseId);
            }

            warehouse.UpdateWarehouse(warehouseName: request.WarehouseName);

            return await _warehouseRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }


    }
}
