namespace WMS.Application.Commands.MaterialCommands.Materials
{
    public class DeleteMaterialPropertyCommand : IRequest<bool>
    {
        public string PropertyId { get; set; }

        public DeleteMaterialPropertyCommand(string propertyId)
        {
            PropertyId = propertyId;
        }
    }
}
