namespace WMS.Application.Commands.StorageCommands.Locations
{
    public class UpdateLocationCommand : IRequest<bool>
    {
        public string LocationId { get; set; }
        public string WarehouseId { get; set; }

        public UpdateLocationCommand(string locationId, string warehouseId)
        {
            LocationId = locationId;
            WarehouseId = warehouseId;
        }
    }
}
