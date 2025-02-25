namespace WMS.Application.ErrorNotifications.ErrorDetails
{
    public class InvalidProductIssueQuantityErrorDetail
    {
        public string? ItemId { get; set; }
        public string? Unit { get; set; }
        public string? PurchaseOrderNumber { get; set; }
        public double ProductInventoryQuantity { get; set; }
        public double ProductIssueQuantity { get; set; }

        public InvalidProductIssueQuantityErrorDetail(string? itemId, string? unit, string? purchaseOrderNumber,
            double productInventoryQuantity, double productIssueQuantity)
        {
            ItemId = itemId;
            Unit = unit;
            PurchaseOrderNumber = purchaseOrderNumber;
            ProductInventoryQuantity = productInventoryQuantity;
            ProductIssueQuantity = productIssueQuantity;
        }
    }
}
