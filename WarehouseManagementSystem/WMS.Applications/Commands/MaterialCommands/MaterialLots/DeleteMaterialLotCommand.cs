namespace WMS.Application.Commands.MaterialCommands.MaterialLots
{
    public class DeleteMaterialLotCommand : IRequest<bool>
    {
        public string LotNumber { get; set; }

        public DeleteMaterialLotCommand(string lotNumber)
        {
            LotNumber = lotNumber;
        }
    }
}
