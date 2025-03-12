namespace WMS.Application.DTOs.StorageDTOs
{
    public class LocationDTO
    {
        public string LocationId { get; set; }
        public string WarehouseName { get; set; }
        public List<MaterialSubLotDTO> MaterialSubLotDTOs { get; set; }
        

        public LocationDTO()
        {
        }

        public LocationDTO(string locationId, string warehouseName, List<MaterialSubLotDTO> materialSubLotDTOs) : this(locationId, warehouseName)
        {
            MaterialSubLotDTOs = materialSubLotDTOs;
        }

        public LocationDTO(string locationId, string warehouseName)
        {
            LocationId = locationId;
            WarehouseName = warehouseName;
            MaterialSubLotDTOs = new List<MaterialSubLotDTO>();
        }
        
        public void MapName(string name)
        {
            WarehouseName = name;
        }
    }
}
