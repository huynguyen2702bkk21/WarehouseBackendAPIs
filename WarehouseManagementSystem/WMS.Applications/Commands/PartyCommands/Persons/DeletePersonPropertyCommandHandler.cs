namespace WMS.Application.Commands.PartyCommands.Persons
{
    public class DeletePersonPropertyCommandHandler : IRequestHandler<DeletePersonPropertyCommand,bool>
    {
        private readonly IPersonPropertyRepository _personPropertyRepository;

        public DeletePersonPropertyCommandHandler(IPersonPropertyRepository personPropertyRepository)
        {
            _personPropertyRepository = personPropertyRepository;
        }

        public async Task<bool> Handle(DeletePersonPropertyCommand request, CancellationToken cancellationToken)
        {
            var personProperty = await _personPropertyRepository.GetByIdAsync(request.PropertyId);
            if (personProperty == null)
            {
                throw new EntityNotFoundException(nameof(PersonProperty), request.PropertyId);
            }

            _personPropertyRepository.Delete(personProperty);

            return await _personPropertyRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);


        }


    }
}
