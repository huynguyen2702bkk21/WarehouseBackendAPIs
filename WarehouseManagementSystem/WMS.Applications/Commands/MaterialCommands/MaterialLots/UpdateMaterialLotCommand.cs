using WMS.Application.Commands.MaterialCommands.MaterialSubLots;

namespace WMS.Application.Commands.MaterialCommands.MaterialLots
{
    public class UpdateMaterialLotCommand : IRequest<bool>
    {
        public string LotNumber { get; set; }
        public string LotStatus { get; set; }
        public string MaterialId { get; set; }
        public double ExisitingQuantity { get; set; }
        public List<CreateMaterialLotPropertyCommand> Properties { get; set; }
        public List<CreateMaterialSubLotCommand> SubLots { get; set; }

        public UpdateMaterialLotCommand(string lotNumber, string lotStatus, string materialId, double exisitingQuantity, List<CreateMaterialLotPropertyCommand> properties, List<CreateMaterialSubLotCommand> subLots)
        {
            LotNumber = lotNumber;
            LotStatus = lotStatus;
            MaterialId = materialId;
            ExisitingQuantity = exisitingQuantity;
            Properties = properties;
            SubLots = subLots;
        }
    }
}
