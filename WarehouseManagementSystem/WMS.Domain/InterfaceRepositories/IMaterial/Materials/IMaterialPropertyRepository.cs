namespace WMS.Domain.InterfaceRepositories.IMaterial
{
    public interface IMaterialPropertyRepository : IRepository<MaterialProperty>
    {
        Task<List<MaterialProperty>> GetAllAsync();
        Task<MaterialProperty> GetByIdAsync(string materialPropertyId);
        void Create(MaterialProperty materialProperty);
        void Delete(MaterialProperty materialProperty);
        void Update(MaterialProperty materialProperty);

    }
}
