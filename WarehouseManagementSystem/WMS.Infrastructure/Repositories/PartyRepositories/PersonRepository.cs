namespace WMS.Infrastructure.Repositories.PartyRepositories
{
    public class PersonRepository : BaseRepository, IPersonRepository
    {
        public PersonRepository(WMSDbContext context) : base(context)
        {

        }

        public Task<List<Person>> GetAll()
        {
            return _context.Persons.ToListAsync();
        }
    }
}
