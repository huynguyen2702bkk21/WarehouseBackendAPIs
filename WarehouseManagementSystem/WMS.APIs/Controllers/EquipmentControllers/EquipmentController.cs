using WMS.Application.DTOs.EquipmentDTOs;
using WMS.Application.Queries.EquipmentQueries.EquipmentProperties;
using WMS.Application.Queries.EquipmentQueries.Equipments;

namespace WMS.APIs.Controllers.EquipmentControllers
{
    [ApiController]
    [Route("WarehouseAPI/[controller]")]
    public class EquipmentController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        public EquipmentController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllEquipmentProperties")]
        public async Task<IEnumerable<EquipmentPropertyDTO>> GetAllEquipmentProperties()
        {
            var query = new GetAllEquipmentPropertiesQuery();
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet("GetEquipmentPropertyById/{equipmentPropertyId}")]
        public async Task<EquipmentPropertyDTO> GetEquipmentPropertyById(string equipmentPropertyId)
        {
            var query = new GetEquipmentPropertyByIdQuery(equipmentPropertyId);
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet("GetAllEquipments")]
        public async Task<IEnumerable<EquipmentDTO>> GetAllEquipments()
        {
            var query = new GetAllEquipmentsQuery();
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet("GetEquipmentById/{equipmentId}")]
        public async Task<EquipmentDTO> GetEquipmentById(string equipmentId)
        {
            var query = new GetEquipmentByIdQuery(equipmentId);
            var result = await _mediator.Send(query);

            return result;
        }
    }
}
