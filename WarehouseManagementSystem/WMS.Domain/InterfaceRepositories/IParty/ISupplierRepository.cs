namespace WMS.Domain.InterfaceRepositories.IParty
{
    public interface ISupplierRepository : IRepository<Supplier>
    {
        Task<List<Supplier>> GetAllAsync();
        Task<Supplier> GetByIdAsync(string id);
        void Create(Supplier supplier);
        void Delete(Supplier supplier);
        void Update(Supplier supplier);


    }
}
