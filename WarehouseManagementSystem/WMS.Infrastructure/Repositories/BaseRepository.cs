namespace WMS.Infrastructure.Repositories
{
    public class BaseRepository
    {
        protected readonly WMSDbContext _context;
        public IUnitOfWork UnitOfWork => _context;


        public BaseRepository(WMSDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}
