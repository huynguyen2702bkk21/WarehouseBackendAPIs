using WMS.Domain.AggregateModels.PartyAggregate.People;
using WMS.Domain.InterfaceRepositories.IParty.People;

namespace WMS.Application.Commands.PartyCommands.Persons
{
    public class CreatePersonPropertyCommandHandler : IRequestHandler<CreatePersonPropertyCommand,bool>
    {
        private readonly IPersonPropertyRepository _personPropertyRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public CreatePersonPropertyCommandHandler(IPersonPropertyRepository personPropertyRepository, IPersonRepository personRepository, IMapper mapper)
        {
            _personPropertyRepository = personPropertyRepository;
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreatePersonPropertyCommand request, CancellationToken cancellationToken)
        {
            var personProperty = await _personPropertyRepository.GetByIdAsync(request.PropertyId);
            if (personProperty != null)
            {
                throw new DuplicateRecordException(nameof(PersonProperty), request.PropertyId);
            }

            var person = await _personRepository.GetPersonById(request.PersonId);
            if (person == null)
            {
                throw new EntityNotFoundException(nameof(Person), request.PersonId);
            }

            if (!Enum.TryParse<UnitOfMeasure>(request.UnitOfMeasure, out var unitOfMeasure))
            {
                throw new ArgumentException("Invalid status value", nameof(request.UnitOfMeasure));
            }

            var newPersonProperty = new PersonProperty(propertyId: request.PropertyId,
                                                       propertyName: request.PropertyName,
                                                       propertyValue: request.PropertyValue,
                                                       unitOfMeasure: unitOfMeasure,
                                                       personId: request.PersonId);

            _personPropertyRepository.Create(newPersonProperty);

            return await _personPropertyRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }



    }
}
