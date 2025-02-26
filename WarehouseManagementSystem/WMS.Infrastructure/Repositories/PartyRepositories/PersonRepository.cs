namespace WMS.Infrastructure.Repositories.PartyRepositories
{
    public class PersonRepository : BaseRepository, IPersonRepository
    {
        public PersonRepository(WMSDbContext context) : base(context)
        {

        }

        public void Create(Person person)
        {
            _context.Add(person);
        }

        public async Task<List<Person>> GetAllAsync()
        {
            return await _context.Persons.ToListAsync();
        }

        public async Task<Person> GetPersonById(string id)
        {
            return await _context.Persons.FirstOrDefaultAsync(x => x.personId== id);
        }

        public void Update(Person person)
        {
            _context.Persons.Update(person);
        }

        public void Delete(Person person)
        {
            _context.Persons.Remove(person);
        }

    }
}
