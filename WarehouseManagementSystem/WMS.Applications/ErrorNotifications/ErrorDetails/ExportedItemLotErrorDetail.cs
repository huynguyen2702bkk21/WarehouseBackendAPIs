namespace WMS.Application.ErrorNotifications.ErrorDetails
{
    public class ExportedItemLotErrorDetail
    {
        public string ItemLotId { get; set; }

        public ExportedItemLotErrorDetail(string itemLotId)
        {
            ItemLotId = itemLotId;
        }
    }
}
