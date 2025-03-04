namespace WMS.APIs.Controllers.InventoryReceiptControllers
{
    [ApiController]
    [Route("WarehouseAPI/[controller]")]
    public class InventoryReceiptLotController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        public InventoryReceiptLotController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllReceiptLots")]
        public async Task<IEnumerable<ReceiptLotDTO>> GetAllReceiptLots()
        {
            var query = new GetAllReceiptLotsQuery();
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet("GetReceiptLotById/{receiptLotId}")]
        public async Task<ReceiptLotDTO> GetReceiptLotById(string receiptLotId)
        {
            var query = new GetReceiptLotByIdQuery(receiptLotId);
            var result = await _mediator.Send(query);

            return result;
        }


    }
}
