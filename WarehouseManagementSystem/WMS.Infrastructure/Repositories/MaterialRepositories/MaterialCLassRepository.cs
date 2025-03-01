﻿
namespace WMS.Infrastructure.Repositories.MaterialRepositories
{
    public class MaterialCLassRepository : BaseRepository, IMaterialClassRepository
    {
        public MaterialCLassRepository(WMSDbContext context) : base(context)
        {
        }

        public void Create(MaterialClass materialClass)
        {
            _context.MaterialClasses.Add(materialClass);
        }

        public async Task<List<MaterialClass>> GetAllAsync()
        {
            return await _context.MaterialClasses.ToListAsync();
        }

        public async Task<MaterialClass> GetByIdAsync(string Id)
        {
            var materialClass = await _context.MaterialClasses.FirstOrDefaultAsync(x => x.materialClassId== Id);
            if (materialClass == null)
            {
                throw new Exception($"MaterialClass With Id: {Id} not Found");
            }

            var properties = await _context.MaterialClassProperties.Where(x => x.materialClassId == Id).ToListAsync();
            if(properties == null)
            {
                properties = new List<MaterialClassProperty>();
            }

            materialClass.properties = properties;

            return materialClass;

        }

        public async Task<MaterialClass> GetById(string Id)
        {
            var materialClass = await _context.MaterialClasses.FirstOrDefaultAsync(x => x.materialClassId == Id);

            return materialClass;

        }

        public void Delete(MaterialClass materialClass)
        {
            _context.MaterialClasses.Remove(materialClass);
        }

        public void Update(MaterialClass materialClass)
        {
            _context.MaterialClasses.Update(materialClass);
        }
    }
}
