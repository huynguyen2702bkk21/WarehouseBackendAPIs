namespace WMS.Application.Exceptions
{
    [Serializable]
    public class DuplicateRecordException : Exception
    {
        public string EntityType { get; } = "";
        public string EntityId { get; } = "";

        public DuplicateRecordException(string message) : base(message)
        {

        }

        public DuplicateRecordException(string? message, Exception? innerException) : base(message, innerException)
        {

        }

        public DuplicateRecordException(string entityType, string entityId) : this($"The entity of type '{entityType}' with id '{entityId}' already exists.")
        {
            EntityType = entityType;
            EntityId = entityId;
        }

        protected DuplicateRecordException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(serializationInfo, streamingContext)
        {

        }
    }
}
