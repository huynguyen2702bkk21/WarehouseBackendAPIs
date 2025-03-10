﻿using WMS.Application.Commands.InventoryReceiptCommands.InventoryReceipts;
using WMS.Application.Queries.InventoryReceiptQueries.InventoryReceiptEntries;

namespace WMS.APIs.Controllers.InventoryReceiptControllers
{
    [ApiController]
    [Route("WarehouseAPI/[controller]")]
    public class InventoryReceiptController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        public InventoryReceiptController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllReceipts")]
        public async Task<IEnumerable<InventoryReceiptDTO>> GetAllReceipts()
        {
            var query = new GetAllInventoryReceiptsQuery();
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet("GetReceiptById/{receiptId}")]
        public async Task<InventoryReceiptDTO> GetReceiptById(string receiptId)
        {
            var query = new GetInventoryReceiptByIdQuery(receiptId);
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpPost("CreateReceipt")]
        public async Task<IActionResult> CreateReceipt([FromBody] CreateInventoryReceiptCommand command)
        {
            return await CommandAsync(command);
        }


    }
}
