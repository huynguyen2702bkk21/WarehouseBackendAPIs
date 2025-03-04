namespace WMS.Application.Commands.MaterialCommands.MaterialLots
{
    public class DeleteMaterialLotPropertyCommand : IRequest<bool>
    {
        public string PropertyId { get; set; }

        public DeleteMaterialLotPropertyCommand(string propertyId)
        {
            PropertyId = propertyId;
        }
    }
}
