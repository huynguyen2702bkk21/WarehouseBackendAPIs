namespace WMS.Application.Queries.StorageQueries.Locations
{
    public class GetLocationsByWarehouseIdQuery : IRequest<List<LocationDTO>>
    {
        public string WarehouseId { get; set; }

        public GetLocationsByWarehouseIdQuery(string warehouseId)
        {
            WarehouseId = warehouseId;
        }
    }
}
