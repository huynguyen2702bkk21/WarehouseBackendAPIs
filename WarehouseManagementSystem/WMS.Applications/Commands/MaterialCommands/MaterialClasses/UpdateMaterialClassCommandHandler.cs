﻿using WMS.Domain.AggregateModels.MaterialAggregate;

namespace WMS.Application.Commands.MaterialCommands.MaterialClasses
{
    public class UpdateMaterialClassCommandHandler : IRequestHandler<UpdateMaterialClassCommand,bool>
    {
        private readonly IMaterialClassRepository _materialClassRepository;
        private readonly IMaterialClassPropertyRepository _materialClassPropertyRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UpdateMaterialClassCommandHandler(IMaterialClassRepository materialClassRepository, IMaterialClassPropertyRepository materialClassPropertyRepository, IMediator mediator, IMapper mapper)
        {
            _materialClassRepository = materialClassRepository;
            _materialClassPropertyRepository = materialClassPropertyRepository;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateMaterialClassCommand request, CancellationToken cancellationToken)
        {
            var materialClass = await _materialClassRepository.GetByIdAsync(request.MaterialClassId);
            if (materialClass == null)
            {
                throw new Exception("Material class not found");
            }

            foreach(var property in request.Properties)
            {
                var materialClassProperty = await _materialClassPropertyRepository.GetByIdAsync(property.PropertyId);
                if (materialClassProperty == null)
                {
                    throw new Exception("Material class property not found");
                }
                materialClassProperty.Update(property.PropertyName, property.PropertyValue, property.UnitOfMeasure);
            }

            materialClass.Update(request.ClassName);
            
            _materialClassRepository.Update(materialClass);

            return await _materialClassRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
 

    }
}
