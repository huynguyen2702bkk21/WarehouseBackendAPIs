
using WMS.Application.Queries.MaterialQueries.MaterialLots;

namespace WMS.APIs.Controllers.MaterialControllers
{
    [ApiController]
    [Route("WarehouseAPI/[controller]")]
    public class MaterialLotController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        public MaterialLotController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllMaterialLotProperties")]
        public async Task<IEnumerable<MaterialLotPropertyDTO>> GetAllProperties()
        {
            var query = new GetAllMaterialLotPropertiesQuery();
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet("GetAllMaterialLots")]
        public async Task<IEnumerable<MaterialLotDTO>> GetAllMaterialLots()
        {
            var query = new GetAllMaterialLotsQuery();
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet("GetMaterialLotById/{id}")]
        public async Task<MaterialLotDTO> GetMaterialLotById(string id)
        {
            var query = new GetMaterialLotByIdQuery(id);
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet("GetMaterialLotPropertyById/{id}")]
        public async Task<MaterialLotPropertyDTO> GetMaterialLotPropertyById(string id)
        {
            var query = new GetMaterialLotPropertyByIdQuery(id);
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet("GetMaterialLotsByMaterialId/{materialId}")]
        public async Task<IEnumerable<MaterialLotDTO>> GetMaterialLotsByMaterialId(string materialId)
        {
            var query = new GetMaterialLotsByMaterialIdQuery(materialId);
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet("Get MaterialLot by LotStatus/{status}")]
        public async Task<IEnumerable<MaterialLotDTO>> GetMaterialLotsByStatus(string status)
        {
            var query = new GetMaterialLotsByStatusQuery(status);
            var result = await _mediator.Send(query);

            return result;
        }

    }
}
