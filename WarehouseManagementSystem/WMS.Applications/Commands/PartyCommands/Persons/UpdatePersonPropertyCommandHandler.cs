using DocumentFormat.OpenXml.Drawing.Diagrams;

namespace WMS.Application.Commands.PartyCommands.Persons
{
    public class UpdatePersonPropertyCommandHandler : IRequestHandler<UpdatePersonPropertyCommand, bool>
    {
        private readonly IPersonPropertyRepository _personPropertyRepository;

        public UpdatePersonPropertyCommandHandler(IPersonPropertyRepository personPropertyRepository)
        {
            _personPropertyRepository = personPropertyRepository;
        }

        public async Task<bool> Handle(UpdatePersonPropertyCommand request, CancellationToken cancellationToken)
        {
            var personProperty = await _personPropertyRepository.GetByIdAsync(request.PropertyId);
            if (personProperty == null)
            {
                throw new EntityNotFoundException(nameof(PersonProperty), request.PropertyId);
            }

            if (!Enum.TryParse<UnitOfMeasure>(request.UnitOfMeasure, out var unitOfMeasure))
            {
                throw new ArgumentException("Invalid status value", nameof(request.UnitOfMeasure));
            }

            personProperty.Update(request.PropertyName, request.PropertyValue, unitOfMeasure);

            return await _personPropertyRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
