using WMS.Application.ErrorNotifications.ErrorDetails;
using WMS.Application.Exceptions;

namespace WMS.Application.ErrorNotifications
{
    public class ErrorResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public object Detail { get; set; }

        public ErrorResponse(string errorCode, string message, object detail)
        {
            Code = errorCode;
            Message = message;
            Detail = detail;
        }

        public ErrorResponse(Exception ex)
        {
            Code = "Unexpected";
            Message = ex.Message;
            var innerMessage = ex.InnerException?.Message;
            if (!string.IsNullOrEmpty(innerMessage))
            {
                Detail = innerMessage;
            }
            else
            {
                Detail = "";
            }
        }

        public ErrorResponse(DuplicateRecordException ex)
        {
            Code = $"RecordDuplication.{ex.EntityType}";
            Message = $"The entity of type '{ex.EntityType}' with ID '{ex.EntityId}' already exists";
            Detail = new DuplicatedRecordErrorDetail(ex.EntityType, ex.EntityId);
        }

        public ErrorResponse(EntityNotFoundException ex)
        {
            Code = $"NotFound.{ex.EntityType}";
            Message = $"The entity of type {ex.EntityType} with ID {ex.EntityId} not found.";
            Detail = new EntityNotFoundErrorDetail(ex.EntityType, ex.EntityId);
        }

        public ErrorResponse(InvalidProductIssueQuantityException ex)
        {
            Code = "InvalidProductQuantity";
            Message = "The quantity of ProductIssue cannot be greater than that of ProductInventory";
            Detail = new InvalidProductIssueQuantityErrorDetail(ex.ItemId, ex.Unit, ex.PurchaseOrderNumber, ex.ProductInventoryQuantity,
                ex.ProductIssueQuantity);
        }

        public ErrorResponse(ExportedItemLotException ex)
        {
            Code = $"ExportedItemLot.{ex.ItemLotId}";
            Message = $"Itemlot with ID {ex.ItemLotId} is exported";
            Detail = new ExportedItemLotErrorDetail(ex.ItemLotId);
        }
    }
}
