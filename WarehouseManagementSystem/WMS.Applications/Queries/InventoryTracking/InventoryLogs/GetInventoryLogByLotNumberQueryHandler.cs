namespace WMS.Application.Queries.InventoryTracking.InventoryLogs
{
    public class GetInventoryLogByLotNumberQueryHandler : IRequestHandler<GetInventoryLogByLotNumberQuery, IEnumerable<InventoryLogDTO>>
    {
        private readonly IInventoryLogRepository _inventoryLogRepository;
        private readonly IMapper _mapper;

        public GetInventoryLogByLotNumberQueryHandler(IInventoryLogRepository inventoryLogRepository, IMapper mapper)
        {
            _inventoryLogRepository = inventoryLogRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InventoryLogDTO>> Handle(GetInventoryLogByLotNumberQuery request, CancellationToken cancellationToken)
        {
            var inventoryLogs = await _inventoryLogRepository.GetInventoryLogByLotNumber(request.LotNumber);
            if (inventoryLogs.Count == 0) 
            {
                throw new EntityNotFoundException("InventoryLog Not Found");
            }

            var inventoryLogDTOs = _mapper.Map<IEnumerable<InventoryLogDTO>>(inventoryLogs);

            return inventoryLogDTOs;

        }


    }
}
