namespace WMS.Application.Queries.EquipmentQueries.EquipmentClassProperties
{
    public class GetEquipmentCLassPropertyByIdQuery : IRequest<EquipmentCLassPropertyDTO>
    {
        public string EquipmentClassPropertyId { get; set; }

        public GetEquipmentCLassPropertyByIdQuery(string equipmentClassPropertyId)
        {
            EquipmentClassPropertyId = equipmentClassPropertyId;
        }
    }
}
