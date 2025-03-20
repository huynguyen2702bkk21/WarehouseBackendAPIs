using WMS.Application.Queries.InventoryReceiptQueries.InventoryReceiptEntries;

namespace WMS.Application.Queries.InventoryReceiptQueries.InventoryReceipts
{
    public class GetAllInventoryReceiptsQueryHandler : IRequestHandler<GetAllInventoryReceiptsQuery, IEnumerable<InventoryReceiptDTO>>
    {
        private readonly IInventoryReceiptRepository _inventoryReceiptRepository;
        private readonly IPersonRepository _personRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IMapper _mapper;

        public GetAllInventoryReceiptsQueryHandler(IInventoryReceiptRepository inventoryReceiptRepository, IPersonRepository personRepository, ISupplierRepository supplierRepository, IWarehouseRepository warehouseRepository, IMapper mapper)
        {
            _inventoryReceiptRepository = inventoryReceiptRepository;
            _personRepository = personRepository;
            _supplierRepository = supplierRepository;
            _warehouseRepository = warehouseRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InventoryReceiptDTO>> Handle(GetAllInventoryReceiptsQuery request, CancellationToken cancellationToken)
        {
            var inventoryReceipts = await _inventoryReceiptRepository.GetAllAsync();
            if (inventoryReceipts.Count == 0)
            {
                throw new Exception("No inventory receipts found");
            }

            var inventoryReceiptDTOs = new List<InventoryReceiptDTO>();

            foreach (var inventoryReceipt in inventoryReceipts)
            {
                var inventoryReceiptDTO = _mapper.Map<InventoryReceiptDTO>(inventoryReceipt);

                var person = await _personRepository.GetPersonById(inventoryReceipt.personId);
                if (person == null)
                {
                    throw new EntityNotFoundException(nameof(Person), inventoryReceipt.personId);
                }

                var supplier = await _supplierRepository.GetByIdAsync(inventoryReceipt.supplierId);
                if (supplier == null)
                {
                    throw new EntityNotFoundException(nameof(Supplier), inventoryReceipt.supplierId);
                }

                var warehouse = await _warehouseRepository.GetWarehouseById(inventoryReceipt.warehouseId);
                if (warehouse == null)
                {
                    throw new EntityNotFoundException(nameof(Warehouse), inventoryReceipt.warehouseId);
                }

                inventoryReceiptDTO.MapName(person.personName, warehouse.warehouseName, supplier.supplierName);

                inventoryReceiptDTOs.Add(inventoryReceiptDTO);
            }
            return inventoryReceiptDTOs;
        }
    }
}
