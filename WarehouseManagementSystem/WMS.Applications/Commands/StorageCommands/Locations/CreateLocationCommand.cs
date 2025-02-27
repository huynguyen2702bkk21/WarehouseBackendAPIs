namespace WMS.Application.Commands.StorageCommands.Locations
{
    public class CreateLocationCommand : IRequest<bool>
    {
        public string LocationId { get; set; }
        public string WarehouseId { get; set; }

        public CreateLocationCommand(string locationId, string warehouseId)
        {
            LocationId = locationId;
            WarehouseId = warehouseId;
        }
    }
}
