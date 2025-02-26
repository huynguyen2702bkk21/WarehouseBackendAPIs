namespace WMS.Application.Commands.PartyCommands.Suppliers
{
    public class UpdateSupplierCommandHandler : IRequestHandler<UpdateSupplierCommand, bool>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public UpdateSupplierCommandHandler(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplier = await _supplierRepository.GetByIdAsync(request.SupplierId);
            if (supplier == null)
            {
                throw new EntityNotFoundException(nameof(Supplier), request.SupplierId);
            }

            supplier.UpdateSupplier(supplierName: request.SupplierName,
                                    address: request.Address,
                                    contactDetails: request.ContactDetails);

            _supplierRepository.Update(supplier);

            return await _supplierRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        }
    }
}
