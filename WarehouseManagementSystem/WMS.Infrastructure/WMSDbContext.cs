namespace WMS.Infrastructure
{
    public class WMSDbContext : DbContext, IUnitOfWork
    {
        // Person Aggregate
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Employee> Employees { get; set; }

        // Storage Aggregate
        public DbSet<Location> Locations { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }

        // Material Aggregate
        public DbSet<Material> Materials { get; set; }
        public DbSet<MaterialProperty> MaterialProperties { get; set; }
        public DbSet<MaterialClass> MaterialClasses { get; set; }
        public DbSet<MaterialClassProperty> MaterialClassProperties { get; set; }
        public DbSet<MaterialLot> MaterialLots { get; set; }
        public DbSet<MaterialLotProperty> MaterialLotProperties { get; set; }
        public DbSet<MaterialSubLot> MaterialSubLots { get; set; }




        





        private readonly IMediator _mediator;

        private IDbContextTransaction? _currentTransaction;
        public IDbContextTransaction? GetCurrentTransaction() => _currentTransaction;
        public bool HasActiveTransaction => _currentTransaction != null;

//#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
//        public WMSDbContext(DbContextOptions options) : base(options) { }
//#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public WMSDbContext(DbContextOptions options, IMediator mediator) : base(options)
        {
            _mediator = mediator;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // person aggregate
            modelBuilder.ApplyConfiguration(new EmployeeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SupplierEntityTypeConfiguration());

            // storage aggregate
            modelBuilder.ApplyConfiguration(new WarehouseEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LocationEntityTypeConfiguration());

            // material aggregate
            modelBuilder.ApplyConfiguration(new MaterialEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MaterialPropertyEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MaterialClassEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MaterialClassPropertyEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MaterialLotEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MaterialLotPropertyEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MaterialSubLotEntityTypeConfiguration());




            base.OnModelCreating(modelBuilder);

        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            await _mediator.DispatchDomainEventsAsync(this);
            await base.SaveChangesAsync(cancellationToken);

            return true;
        }
        public async Task<IDbContextTransaction?> BeginTransactionAsync()
        {
            if (_currentTransaction != null) return null;

            _currentTransaction = await Database.BeginTransactionAsync();

            return _currentTransaction;
        }
        public async Task CommitTransactionAsync(IDbContextTransaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));
            if (transaction != _currentTransaction) throw new InvalidOperationException($"Transaction {transaction.TransactionId} is not current");

            try
            {
                await SaveChangesAsync();
                transaction.Commit();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }
    }
}
