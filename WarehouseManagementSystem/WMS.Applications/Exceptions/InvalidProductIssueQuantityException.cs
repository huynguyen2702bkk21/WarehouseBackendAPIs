namespace WMS.Application.Exceptions
{
    [Serializable]
    public class InvalidProductIssueQuantityException : Exception
    {
        public string? ItemId { get; set; }
        public string? Unit { get; set; }
        public string? PurchaseOrderNumber { get; set; }
        public double ProductInventoryQuantity { get; set; }
        public double ProductIssueQuantity { get; set; }

        public InvalidProductIssueQuantityException(string itemId, string unit, string purchaseOrderNumber,
            double productInventoryQuantity, double productIssueQuantity) :
            this($"The quantity of ProductIssue with itemId {itemId} & unit {unit} cannot be greater than that" +
                $"of ProductInventory")
        {
            ItemId = itemId;
            Unit = unit;
            PurchaseOrderNumber = purchaseOrderNumber;
            ProductInventoryQuantity = productInventoryQuantity;
            ProductIssueQuantity = productIssueQuantity;
        }

        public InvalidProductIssueQuantityException(string? message, Exception? innerException) : base(message, innerException)
        {

        }

        public InvalidProductIssueQuantityException(string message) : base(message)
        {

        }

        protected InvalidProductIssueQuantityException(SerializationInfo serializationInfo, StreamingContext streamingContext)
        {

        }
    }
}
