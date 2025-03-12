
namespace WMS.Infrastructure.Repositories.EquipmentRepositories
{
    public class EquipmentRepository : BaseRepository, IEquipmentRepository
    {
        public EquipmentRepository(WMSDbContext context) : base(context)
        {
        }

        public void Create(Equipment equipment)
        {
            _context.Equipments.Add(equipment);
        }

        public void Delete(Equipment equipment)
        {
            _context.Equipments.Remove(equipment);
        }

        public async Task<List<Equipment>> GetAllAsync()
        {
            return await _context.Equipments.ToListAsync();
        }

        public async Task<Equipment> GetByIdAsync(string equipmentId)
        {
            var equipment =  await _context.Equipments
                .Include(x => x.properties)
                .FirstOrDefaultAsync(x => x.equipmentId == equipmentId);

            return equipment;
        }
    }
}
