namespace WMS.Application.DTOs.StorageDTOs
{
    public class LocationDTO
    {
        public string LocationId { get; set; }
        public string WarehouseName { get; set; }

        public LocationDTO(string locationId, string warehouseName)
        {
            LocationId = locationId;
            WarehouseName = warehouseName;
        }                  
    }
}
