namespace WMS.Domain.InterfaceRepositories.IMaterial
{
    public interface IMaterialClassPropertyRepository : IRepository<MaterialClassProperty>
    {
        Task<List<MaterialClassProperty>> GetAllAsync();
        Task<MaterialClassProperty> GetByIdAsync(string id);
        void Create(MaterialClassProperty materialClassProperty);
        void Delete(MaterialClassProperty materialClassProperty);
        void Update(MaterialClassProperty materialClassProperty);

    }
}
