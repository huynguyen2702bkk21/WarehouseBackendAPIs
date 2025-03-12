namespace WMS.Application.DTOs.StorageDTOs
{
    public class WarehouseDTO
    {
        public string WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public List<LocationDTO> Locations { get; set; }

        public WarehouseDTO()
        {
        }

        public WarehouseDTO(string warehouseId, string warehouseName, List<LocationDTO> locations)
        {
            WarehouseId = warehouseId;
            WarehouseName = warehouseName;
            Locations = locations;
        }
    }
}
