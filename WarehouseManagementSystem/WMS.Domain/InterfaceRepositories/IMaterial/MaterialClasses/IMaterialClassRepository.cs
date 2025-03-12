namespace WMS.Domain.InterfaceRepositories.IMaterial
{
    public interface IMaterialClassRepository : IRepository<MaterialClass>
    {
        Task<List<MaterialClass>> GetAllAsync();
        Task<MaterialClass> GetByIdAsync(string Id);
        Task<MaterialClass> GetById(string Id);
        void Create(MaterialClass materialClass);
        void Delete(MaterialClass materialClass);
        void Update(MaterialClass materialClass);

    }
}
