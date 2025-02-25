namespace WMS.Application.ErrorNotifications.ErrorDetails
{
    public class DuplicatedRecordErrorDetail
    {
        public string EntityType { get; set; }
        public string EntityId { get; set; }

        public DuplicatedRecordErrorDetail(string entityType, string entityId)
        {
            EntityType = entityType;
            EntityId = entityId;
        }
    }
}
