using System.ComponentModel.DataAnnotations.Schema;
using WMS.Domain.AggregateModels.InventoryIssueAggregate;
using WMS.Domain.AggregateModels.InventoryReceiptAggregate;
using WMS.Domain.AggregateModels.MaterialAggregate;

namespace WMS.Application.DTOs.MaterialDTOs
{
    public class MaterialDTO
    {
        public string MaterialId { get; set; }
        public string MaterialName { get; set; }

    }
}
