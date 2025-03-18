
using WMS.Application.Commands.InventoryReceiptCommands.InventoryReceiptEntries;
using WMS.Application.Commands.InventoryReceiptCommands.InventoryReceipts;
using WMS.Application.Queries.InventoryReceiptQueries.InventoryReceipts;

namespace WMS.APIs.Controllers.InventoryReceiptControllers
{
    [ApiController]
    [Route("WarehouseAPI/[controller]")]
    public class InventoryReceiptEntryController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        public InventoryReceiptEntryController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllReceiptEntries")]
        public async Task<IEnumerable<InventoryReceiptEntryDTO>> GetAllReceiptEntries()
        {
            var query = new GetAllInventoryReceiptEntriesQuery();
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet("GetReceiptEntryById/{receiptEntryId}")]
        public async Task<InventoryReceiptEntryDTO> GetReceiptEntryById(string receiptEntryId)
        {
            var query = new GetInventoryReceiptEntryByIdQuery(receiptEntryId);
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpPost("CreateInventoryReceiptEntry")]
        public async Task<IActionResult> CreateInventoryReceiptEntry([FromBody] CreateInventoryReceiptEntryCommand command)
        {
            return await CommandAsync(command);
        }

        [HttpPut("Update InventoryReceiptEntries")]
        public async Task<IActionResult> UpdateInventoryReceiptEntries([FromBody] UpdateInventoryReceiptEntriesCommand command)
        {
            return await CommandAsync(command);
        }


    }
}
