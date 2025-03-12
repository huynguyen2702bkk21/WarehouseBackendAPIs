namespace WMS.Domain.InterfaceRepositories.IParty
{
    public interface IPersonRepository : IRepository<Person>
    {
        Task<List<Person>> GetAllAsync();
        Task<Person> GetPersonById(string id);
        void Create(Person person);
        void Update(Person person);
        void Delete(Person person);
    }
}
