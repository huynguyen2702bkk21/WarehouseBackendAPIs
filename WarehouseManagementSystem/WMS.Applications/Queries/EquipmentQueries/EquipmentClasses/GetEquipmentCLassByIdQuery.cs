using WMS.Application.DTOs.EquipmentDTOs.EquipmentClasses;

namespace WMS.Application.Queries.EquipmentQueries.EquipmentClasses
{
    public class GetEquipmentCLassByIdQuery : IRequest<EquipmentCLassDTO>
    {
        public string EquipmentCLassId { get; set; }

        public GetEquipmentCLassByIdQuery(string equipmentCLassId)
        {
            EquipmentCLassId = equipmentCLassId;
        }
    }
}
