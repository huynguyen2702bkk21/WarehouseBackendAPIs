namespace WMS.Application.Commands.MaterialCommands.MaterialSubLots
{
    public class DeleteMaterialSubLotCommand : IRequest<bool>
    {
        public string SubLotId { get; set; }

        public DeleteMaterialSubLotCommand(string subLotId)
        {
            SubLotId = subLotId;
        }
    }
}
