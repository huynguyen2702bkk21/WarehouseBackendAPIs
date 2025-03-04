namespace WMS.Domain.InterfaceRepositories.IMaterial
{
    public interface IMaterialRepository : IRepository<Material>
    {
        Task<List<Material>> GetAllAsync();
        Task<Material> GetByIdAsync(string materialId);
        Task<MaterialClass> GetByClassIdAsync(string classId);
        Task<Material> GetById(string id);
        void Create(Material material);
        void Delete(Material material);
        void Update(Material material);
    }
}
