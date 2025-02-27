namespace WMS.Application.Commands.StorageCommands.Warehouses
{
    public class DeleteWarehouseCommandHandler : IRequestHandler<DeleteWarehouseCommand, bool>
    {
        private readonly IWarehouseRepository _warehouseRepository;

        public DeleteWarehouseCommandHandler(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }

        public async Task<bool> Handle(DeleteWarehouseCommand request, CancellationToken cancellationToken)
        {
            var warehouse = await _warehouseRepository.GetWarehouseById(request.WarehouseId);
            if (warehouse == null)
            {
                throw new EntityNotFoundException(nameof(Warehouse), request.WarehouseId);
            }

            _warehouseRepository.Delete(warehouse);

            return await _warehouseRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
