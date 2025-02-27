namespace WMS.Application.Queries.StorageQueries.Warehouses
{
    public class GetWarehouseByIdQuery : IRequest<WarehouseDTO>
    {
        public string WarehouseId { get; set; }

        public GetWarehouseByIdQuery(string warehouseId)
        {
            WarehouseId = warehouseId;
        }
    }
}
