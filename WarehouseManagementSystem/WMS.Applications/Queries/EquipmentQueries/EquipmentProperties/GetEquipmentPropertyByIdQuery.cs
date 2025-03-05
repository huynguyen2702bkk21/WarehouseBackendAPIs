namespace WMS.Application.Queries.EquipmentQueries.EquipmentProperties
{
    public class GetEquipmentPropertyByIdQuery : IRequest<EquipmentPropertyDTO>
    {
        public string PropertyId { get; set; }

        public GetEquipmentPropertyByIdQuery(string propertyId)
        {
            PropertyId = propertyId;
        }
    }
}
