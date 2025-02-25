using WMS.Domain.AggregateModels.PartyAggregate;

namespace WMS.Application.Commands.PartyCommands.Persons
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, bool>
    {
        private readonly IPersonRepository _personRepository;
        private IMapper _mapper;

        public CreatePersonCommandHandler(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var personExisited = await _personRepository.GetPersonById(request.PersonId);

            if (personExisited != null)
            {
                throw new DuplicateRecordException("Persons", request.PersonId);
            }

            var person = new Person(personId: request.PersonId, 
                                    personName: request.PersonName, 
                                    role: request.Role);

            _personRepository.Create(person);

            return await _personRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }

    }
}
