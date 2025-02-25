using MediatR;
using WMS.Application.DTOs.PartyDTOs;
using WMS.Application.Queries.PartyQueries.PersonQueries;
using WMS.Domain.InterfaceRepositories.IParty;

namespace WMS.APIs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMediator _mediator;

        public PersonController(IPersonRepository personRepository, IMediator mediator)
        {
            _personRepository = personRepository;
            _mediator = mediator;
        }

        [HttpGet("Person/Getalll")]
        public async Task<IEnumerable<PersonDTO>> GetAll(CancellationToken cancellationToken)
        {
            var query = new GetAllPersonQuery();
            var result = await _mediator.Send(query);

            return result;

        }



    }
}
