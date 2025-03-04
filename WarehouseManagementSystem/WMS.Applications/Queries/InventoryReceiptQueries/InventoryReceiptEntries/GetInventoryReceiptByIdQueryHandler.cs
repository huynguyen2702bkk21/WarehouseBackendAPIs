using WMS.Application.Queries.InventoryReceiptQueries.InventoryReceipts;

namespace WMS.Application.Queries.InventoryReceiptQueries.InventoryReceiptEntries
{
    public class GetInventoryReceiptByIdQueryHandler : IRequestHandler<GetInventoryReceiptByIdQuery, InventoryReceiptDTO>
    {
        private readonly IInventoryReceiptRepository _inventoryReceiptRepository;
        private readonly IPersonRepository _personRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public GetInventoryReceiptByIdQueryHandler(IInventoryReceiptRepository inventoryReceiptRepository, IPersonRepository personRepository, ISupplierRepository supplierRepository, IWarehouseRepository warehouseRepository, IMapper mapper, IMediator mediator)
        {
            _inventoryReceiptRepository = inventoryReceiptRepository;
            _personRepository = personRepository;
            _supplierRepository = supplierRepository;
            _warehouseRepository = warehouseRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<InventoryReceiptDTO> Handle(GetInventoryReceiptByIdQuery request, CancellationToken cancellationToken)
        {
            var inventoryReceipt = await _inventoryReceiptRepository.GetByIdAsync(request.InventoryReceiptId);
            if (inventoryReceipt == null)
            {
                throw new Exception("No inventory receipt found");
            }

            var person = await _personRepository.GetPersonById(inventoryReceipt.personId);
            if (person == null)
            {
                throw new Exception("Person not found");
            }

            var supplier = await _supplierRepository.GetByIdAsync(inventoryReceipt.supplierId);
            if (supplier == null)
            {
                throw new Exception("Supplier not found");
            }

            var warehouse = await _warehouseRepository.GetWarehouseById(inventoryReceipt.warehouseId);
            if (warehouse == null)
            {
                throw new Exception("Warehouse not found");
            }

            var Entries = new List<InventoryReceiptEntryDTO>();

            foreach (var inventoryReceiptEntry in inventoryReceipt.entries)
            {
                var inventoryReceiptEntryDTO = await _mediator
                    .Send(new GetInventoryReceiptEntryByIdQuery(inventoryReceiptEntry.inventoryReceiptEntryId));

                Entries.Add(inventoryReceiptEntryDTO);
            }

            var inventoryReceiptDTO = new InventoryReceiptDTO(inventoryReceiptId: inventoryReceipt.inventoryReceiptId,
                                                              receiptDate: inventoryReceipt.receiptDate,
                                                              receiptStatus: inventoryReceipt.receiptStatus,
                                                              supplierName: supplier.supplierName,
                                                              personName: person.personName,
                                                              warehouseName: warehouse.warehouseName,
                                                              entries: Entries);


            return inventoryReceiptDTO;
        }
    }
}
