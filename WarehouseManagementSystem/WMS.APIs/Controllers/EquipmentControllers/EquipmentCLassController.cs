using WMS.Application.DTOs.EquipmentDTOs;
using WMS.Application.Queries.EquipmentQueries.EquipmentClasses;
using WMS.Application.Queries.EquipmentQueries.EquipmentClassProperties;

namespace WMS.APIs.Controllers.EquipmentControllers
{
    [ApiController]
    [Route("WarehouseAPI/[controller]")]
    public class EquipmentCLassController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        public EquipmentCLassController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllEquipmentClasses")]
        public async Task<IEnumerable<EquipmentCLassDTO>> GetAllEquipmentClasses()
        {
            var query = new GetAllEquipmentCLassesQuery();
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet("GetEquipmentClassById/{EquipmentClassId}")]
        public async Task<EquipmentCLassDTO> GetEquipmentClassById(string EquipmentClassId)
        {
            var query = new GetEquipmentCLassByIdQuery(EquipmentClassId);
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet("GetAllEquipmentClassProperties")]
        public async Task<IEnumerable<EquipmentCLassPropertyDTO>> GetAllEquipmentClassProperties()
        {
            var query = new GetAllEquipmentCLassPropertiesQuery();
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet("GetEquipmentClassPropertyById/{equipmentClassPropertyId}")]
        public async Task<EquipmentCLassPropertyDTO> GetEquipmentClassPropertyById(string equipmentClassPropertyId)
        {
            var query = new GetEquipmentCLassPropertyByIdQuery(equipmentClassPropertyId);
            var result = await _mediator.Send(query);

            return result;
        }


    }
}
