using WMS.Application.Commands.PartyCommands.Persons;

namespace WMS.APIs.Controllers.PartyControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Persons/Getalll")]
        public async Task<IEnumerable<PersonDTO>> GetAll()
        {
            var query = new GetAllPersonQuery();
            var result = await _mediator.Send(query);

            return result;

        }

        [HttpGet("Persons/GetPersonById/{id}")]
        public async Task<PersonDTO> GetById(string id)
        {
            var query = new GetPersonByIdQuery(id);
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpPost("Persons/CreateSupplier New Persons")]
        public async Task<IActionResult> CreatePerson([FromBody] CreatePersonCommand request)
        {
            return await CommandAsync(request);
        }

        [HttpPut("Persons/Update Persons")]
        public async Task<IActionResult> UpdatePerson([FromBody] UpdatePersonCommand request)
        {
            return await CommandAsync(request);
        }

        [HttpDelete("Persons/Delete Persons/{id}")]
        public async Task<IActionResult> DeletePerson(string id)
        {
            var request = new DeletePersonCommand(id);

            return await CommandAsync(request);
        }


    }
}
