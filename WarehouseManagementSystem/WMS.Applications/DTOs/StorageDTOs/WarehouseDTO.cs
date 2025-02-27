namespace WMS.Application.DTOs.StorageDTOs
{
    public class WarehouseDTO
    {
        public string WarehouseId { get; set; }
        public string WarehouseName { get; set; }

        public WarehouseDTO(string warehouseId, string warehouseName)
        {
            WarehouseId = warehouseId;
            WarehouseName = warehouseName;
        }
    }
}
