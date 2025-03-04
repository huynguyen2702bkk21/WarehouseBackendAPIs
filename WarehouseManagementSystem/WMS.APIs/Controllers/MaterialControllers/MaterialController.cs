using WMS.Application.Queries.MaterialQueries.Materials;

namespace WMS.APIs.Controllers.MaterialControllers
{
    [ApiController]
    [Route("WarehouseAPI/[controller]")]
    public class MaterialController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public MaterialController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllMaterialProperties")]
        public async Task<IEnumerable<MaterialPropertyDTO>> GetAllProperties()
        {
            var query = new GetAllMaterialPropertiesQuery();
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet("GetAllMaterials")]
        public async Task<IEnumerable<MaterialDTO>> GetAll()
        {
            var query = new GetAllMaterialQuery();
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet("GetMaterialById/{id}")]
        public async Task<MaterialDTO> GetById(string id)
        {
            var query = new GetMaterialByIdQuery(id);
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet("GetMaterialPropertyById/{id}")]
        public async Task<MaterialPropertyDTO> GetPropertyById(string id)
        {
            var query = new GetMaterialPropertyByIdQuery(id);
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet("GetMaterialsByClassId/{classId}")]
        public async Task<MaterialClassDTO> GetMaterialsByClassId(string classId)
        {
            var query = new GetMaterialsByClassId(classId);
            var result = await _mediator.Send(query);

            return result;
        }

    }
}
