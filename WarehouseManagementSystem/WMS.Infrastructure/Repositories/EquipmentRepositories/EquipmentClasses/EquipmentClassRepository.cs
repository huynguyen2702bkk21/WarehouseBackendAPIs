
namespace WMS.Infrastructure.Repositories.EquipmentRepositories
{
    public class EquipmentClassRepository : BaseRepository, IEquipmentClassRepository
    {
        public EquipmentClassRepository(WMSDbContext context) : base(context)
        {
        }

        public void Create(EquipmentClass equipmentClass)
        {
            _context.EquipmentClasses.Add(equipmentClass);
        }

        public void Delete(EquipmentClass equipmentClass)
        {
            _context.EquipmentClasses.Remove(equipmentClass);
        }

        public async Task<List<EquipmentClass>> GetAllAsync()
        {
            return await _context.EquipmentClasses.ToListAsync();
        }

        public async Task<EquipmentClass> GetByIdAsync(string EquipmentClassId)
        {
            var equipmentClass = await _context.EquipmentClasses
                .Include(s => s.equipments)
                    .ThenInclude(s => s.properties)
                .Include(s => s.properties)
                .FirstOrDefaultAsync(s => s.equipmentClassId == EquipmentClassId);

            return equipmentClass;

        }
    }
}
