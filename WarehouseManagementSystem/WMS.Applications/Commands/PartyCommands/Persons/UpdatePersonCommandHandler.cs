namespace WMS.Application.Commands.PartyCommands.Persons
{
    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand,bool>
    {

        private readonly IMapper _mapper;
        private readonly IPersonRepository _personRepository;
        
            
        public UpdatePersonCommandHandler(IMapper mapper, IPersonRepository personRepository)
        {
            _mapper = mapper;
            _personRepository = personRepository;
        }

        public async Task<bool> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = await _personRepository.GetPersonById(request.PersonId);
            if (person == null)
            {
                throw new EntityNotFoundException(nameof(Person), request.PersonId);
            }

            if (!Enum.TryParse<EmployeeType>(request.Role, out var EmployeeRole))
            {
                throw new ArgumentException("Invalid status value", nameof(request.Role));
            }

            person.UpdatePerson(request.PersonName, EmployeeRole);

            return await _personRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        }
        


    }
}
