namespace WMS.Application.Commands.StorageCommands.Warehouses
{
    public class CreateWarehouseCommand : IRequest<bool>
    {
        public string WarehouseId { get; set; }
        public string WarehouseName { get; set; }

        public CreateWarehouseCommand(string warehouseId, string warehouseName)
        {
            WarehouseId = warehouseId;
            WarehouseName = warehouseName;
        }
    }
}
