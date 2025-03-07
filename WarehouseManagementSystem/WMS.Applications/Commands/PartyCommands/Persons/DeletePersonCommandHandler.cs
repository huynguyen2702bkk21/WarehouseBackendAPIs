namespace WMS.Application.Commands.PartyCommands.Persons
{
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand, bool>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public DeletePersonCommandHandler(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            var persom = await _personRepository.GetPersonById(request.PersonId);
            if (persom == null)
            {
                throw new EntityNotFoundException(nameof(Person), request.PersonId);
            }

            _personRepository.Delete(persom);


            return await _personRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);



        }



    }
}
