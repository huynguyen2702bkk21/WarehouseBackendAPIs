
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
            var materialLot = await _context.MaterialLots.FirstOrDefaultAsync(x => x.lotNumber== lotNumber);
            if (materialLot == null)
            {
                return null;
            }

            var properties = await _context.MaterialLotProperties.Where(x => x.lotNumber== materialLot.lotNumber).ToListAsync();
            if (properties != null)
            {
                materialLot.properties= properties;
            }

            var sublots = await _context.MaterialSubLots.Where(x => x.lotNumber== materialLot.lotNumber).ToListAsync();
            if (sublots != null)
            {
                materialLot.subLots= sublots;
            }

            return materialLot;

        }

        public async Task<List<MaterialLot>> GetMaterialLotsByMaterialId(string materialId)
        {
            var materialLots = await _context.MaterialLots.Where(x => x.materialId== materialId).ToListAsync();
            if (materialLots == null)
            {
                return null;
            }

            //foreach (var materialLot in materialLots)
            //{
            //    var sublots = await _context.MaterialSubLots.Where(x => x.lotNumber == materialLot.lotNumber).ToListAsync();
            //    if (sublots != null)
            //    {
            //        materialLot.subLots = sublots;
            //    }

            //}

            return materialLots;

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
