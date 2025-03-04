namespace WMS.Domain.InterfaceRepositories.IMaterial
{
    public interface IMaterialLotPropertyRepository : IRepository<MaterialLotProperty>
    {
        Task<List<MaterialLotProperty>> GetAllAsync();
        Task<MaterialLotProperty> GetMaterialLotPropertyById(string id);
        void Create(MaterialLotProperty materialLotProperty);
        Task Delete(MaterialLotProperty materialLotProperty);
    }
}
