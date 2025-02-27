namespace WMS.Application.Commands.StorageCommands.Warehouses
{
    public class DeleteWarehouseCommand : IRequest<bool>
    {
        public string WarehouseId { get; set; }

        public DeleteWarehouseCommand(string warehouseId)
        {
            WarehouseId = warehouseId;
        }
    }
}
