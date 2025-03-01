namespace WMS.Application.Commands.MaterialCommands.MaterialClasses
{
    public class UpdateMaterialClassPropertyCommandHandler : IRequestHandler<UpdateMaterialClassPropertyCommand,bool>
    {
        private readonly IMaterialClassPropertyRepository _materialClassPropertyRepository;
        private readonly IMapper _mapper;

        public UpdateMaterialClassPropertyCommandHandler(IMaterialClassPropertyRepository materialClassPropertyRepository, IMapper mapper)
        {
            _materialClassPropertyRepository = materialClassPropertyRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateMaterialClassPropertyCommand request, CancellationToken cancellationToken)
        {
            var materialClassProperty = await _materialClassPropertyRepository.GetByIdAsync(request.PropertyId);
            if (materialClassProperty == null)
            {
                throw new Exception("Material class property not found");
            }

            materialClassProperty.Update(request.PropertyName, request.PropertyValue, request.UnitOfMeasure);

            _materialClassPropertyRepository.Update(materialClassProperty);

            return await _materialClassPropertyRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }



    }
}
