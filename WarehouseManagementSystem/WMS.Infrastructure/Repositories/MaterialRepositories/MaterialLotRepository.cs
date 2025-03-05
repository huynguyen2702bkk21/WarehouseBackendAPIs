
namespace WMS.Infrastructure.Repositories.MaterialRepositories
{
    public class MaterialLotRepository : BaseRepository, IMaterialLotRepository
    {
        public MaterialLotRepository(WMSDbContext context) : base(context)
        {
        }

        public void Create(MaterialLot materialLot)
        {
            _context.MaterialLots.Add(materialLot);
        }

        public void Delete(MaterialLot materialLot)
        {
            _context.MaterialLots.Remove(materialLot);
        }

        public Task<List<MaterialLot>> GetAllAsync()
        {
            return _context.MaterialLots.ToListAsync();
        }

        public async Task<MaterialLot> GetMaterialLotById(string lotNumber)
        {
            var materialLot = await _context.MaterialLots
                .Include(s => s.properties)
                .Include(s => s.subLots)
                .FirstOrDefaultAsync(x => x.lotNumber== lotNumber);

            return materialLot;

        }

        public async Task<List<MaterialLot>> GetMaterialLotsByMaterialId(string materialId)
        {
            return await _context.MaterialLots.Where(x => x.materialId== materialId).ToListAsync();

        }

        public async Task<List<MaterialLot>> GetMaterialLotsByStatus(string status)
        {
            if (!Enum.TryParse<LotStatus>(status, out var statusEnum))
            {
                throw new ArgumentException("Invalid status value", nameof(status));
            }

            return await _context.MaterialLots
                .Where(x => x.lotStatus == statusEnum)
                .ToListAsync();
        }

    }
}
