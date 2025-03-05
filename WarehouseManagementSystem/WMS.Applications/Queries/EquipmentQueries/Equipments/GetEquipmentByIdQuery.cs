namespace WMS.Application.Queries.EquipmentQueries.Equipments
{
    public class GetEquipmentByIdQuery : IRequest<EquipmentDTO>
    {
        public string EquipmentId { get; set; }

        public GetEquipmentByIdQuery(string equipmentId)
        {
            EquipmentId = equipmentId;
        }
    }
}
