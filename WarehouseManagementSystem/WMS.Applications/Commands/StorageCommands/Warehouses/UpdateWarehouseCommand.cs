namespace WMS.Application.Commands.StorageCommands.Warehouses
{
    public class UpdateWarehouseCommand : IRequest<bool>
    {
        public string WarehouseId { get; set; }

        public string WarehouseName { get; set; }

        public UpdateWarehouseCommand(string warehouseId, string warehouseName)
        {
            WarehouseId = warehouseId;
            WarehouseName = warehouseName;
        }
    }

}
