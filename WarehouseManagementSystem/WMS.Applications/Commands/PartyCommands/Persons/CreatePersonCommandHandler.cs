﻿namespace WMS.Application.Commands.PartyCommands.Persons
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
            var person = await _personRepository.GetPersonById(request.PersonId);

            if (person != null)
            {
                throw new DuplicateRecordException("Persons", request.PersonId);
            }

            var newPerson = new Person(personId: request.PersonId, 
                                    personName: request.PersonName, 
                                    role: request.Role);

            _personRepository.Create(newPerson);

            return await _personRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }

    }
}
