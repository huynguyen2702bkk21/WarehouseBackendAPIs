using WMS.Application.DTOs.EquipmentDTOs.EquipmentClasses;

namespace WMS.Application.Queries.EquipmentQueries.EquipmentClasses
{
    public class GetAllEquipmentCLassesQuery : IRequest<IEnumerable<EquipmentCLassDTO>>
    {
        public GetAllEquipmentCLassesQuery()
        {
        }
    }
}
