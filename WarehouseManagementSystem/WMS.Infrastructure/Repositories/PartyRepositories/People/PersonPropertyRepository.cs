using WMS.Domain.InterfaceRepositories.IParty.People;

namespace WMS.Infrastructure.Repositories.PartyRepositories.People
{
    public class PersonPropertyRepository : BaseRepository, IPersonPropertyRepository
    {

        public PersonPropertyRepository(WMSDbContext context) : base(context)
        {
        }

        public void Create(PersonProperty personProperty)
        {
            _context.PersonProperties.Add(personProperty);
        }

        public void Delete(PersonProperty personProperty)
        {
            _context.PersonProperties.Remove(personProperty);
        }

        public async Task<List<PersonProperty>> GetAllPersonProperties()
        {
            return await _context.PersonProperties.ToListAsync();
        }

        public async Task<PersonProperty> GetByIdAsync(string propertyId)
        {
            return await _context.PersonProperties.FirstOrDefaultAsync(x => x.propertyId == propertyId);
        }
    }
}
