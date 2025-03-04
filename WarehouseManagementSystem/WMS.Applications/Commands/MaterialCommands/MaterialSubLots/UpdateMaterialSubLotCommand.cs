namespace WMS.Application.Commands.MaterialCommands.MaterialSubLots
{
    public class UpdateMaterialSubLotCommand : IRequest<bool>
    {
        public string SubLotId { get; set; }
        public string SubLotStatus { get; set; }
        public double ExistingQuality { get; set; }
        public string UnitOfMeasure { get; set; }
        public string LocationId { get; set; }
        public string LotNumber { get; set; }

        public UpdateMaterialSubLotCommand(string subLotId, string subLotStatus, double existingQuality, string unitOfMeasure, string locationId, string lotNumber)
        {
            SubLotId = subLotId;
            SubLotStatus = subLotStatus;
            ExistingQuality = existingQuality;
            UnitOfMeasure = unitOfMeasure;
            LocationId = locationId;
            LotNumber = lotNumber;
        }
    }
}
