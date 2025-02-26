namespace WMS.Application.Commands.PartyCommands.Suppliers
{
    public class CreateSupplierCommandHandler : IRequestHandler<CreateSupplierCommand, bool>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public CreateSupplierCommandHandler(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplier = await _supplierRepository.GetByIdAsync(request.SupplierId);
            if (supplier != null)
            {
                throw new DuplicateRecordException(nameof(Supplier), request.SupplierId);
            }

            var newSupplier = new Supplier(supplierId: request.SupplierId,
                                           supplierName: request.SupplierName,
                                           address: request.Address,
                                           contactDetails: request.ContactDetails);

            _supplierRepository.Create(newSupplier);

            return await _supplierRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }



    }
}
