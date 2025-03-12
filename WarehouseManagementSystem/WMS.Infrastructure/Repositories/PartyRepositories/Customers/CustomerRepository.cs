namespace WMS.Infrastructure.Repositories.PartyRepositories
{
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {
        public CustomerRepository(WMSDbContext context) : base(context)
        {
        }

        public void Create(Customer customer)
        {
            _context.Customers.Add(customer);
        }

        public void Delete(Customer customer)
        {
            _context.Customers.Remove(customer);
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomerById(string Id)
        {
            return await _context.Customers.FirstOrDefaultAsync(x => x.customerId == Id);
        }

        public void Update(Customer customer)
        {
            _context.Customers.Update(customer);
        }
    }
}
