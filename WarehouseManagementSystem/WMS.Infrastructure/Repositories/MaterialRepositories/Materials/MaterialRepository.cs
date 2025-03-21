﻿
namespace WMS.Infrastructure.Repositories.MaterialRepositories
{
    public class MaterialRepository : BaseRepository, IMaterialRepository
    {
        public MaterialRepository(WMSDbContext context) : base(context)
        {
        }

        public void Create(Material material)
        {
            _context.Materials.Add(material);
        }

        public void Delete(Material material)
        {
            _context.Materials.Remove(material);
        }

        public async Task<List<Material>> GetAllAsync()
        {
            return await _context.Materials.ToListAsync();
        }

        public async Task<List<Material>> GetByClassIdAsync(string classId)
        {
            var materials = await _context.Materials
                .Where(s => s.materialClassId == classId)
                .Include(s => s.properties)
                .ToListAsync();

            return materials;

        }

        public async Task<Material> GetById(string id)
        {
            return await _context.Materials.FirstOrDefaultAsync(x => x.materialId == id);
        }

        public async Task<Material> GetByIdAsync(string materialId)
        {
            var material = await _context.Materials
                .Include(s => s.properties)
                .FirstOrDefaultAsync(x => x.materialId== materialId);

            return material;
        }

        public void Update(Material material)
        {
            _context.Materials.Update(material);
        }
    }
}
