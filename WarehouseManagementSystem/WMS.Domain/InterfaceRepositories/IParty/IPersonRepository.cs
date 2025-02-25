namespace WMS.Domain.InterfaceRepositories.IParty
{
    public interface IPersonRepository : IRepository<Person>
    {
        Task<List<Person>> GetAll();
    }
}
