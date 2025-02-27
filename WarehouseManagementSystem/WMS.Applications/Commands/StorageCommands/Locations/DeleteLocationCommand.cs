namespace WMS.Application.Commands.StorageCommands.Locations
{
    public class DeleteLocationCommand : IRequest<bool>
    {
        public string LocationId { get; set; }

        public DeleteLocationCommand(string locationId)
        {
            LocationId = locationId;
        }
    }
}
