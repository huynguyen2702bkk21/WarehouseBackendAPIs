using WMS.Infrastructure.EFConfigurations.EquipmentConfigurations.EquipmentClasses;
using WMS.Infrastructure.EFConfigurations.EquipmentConfigurations.Equipments;
using WMS.Infrastructure.EFConfigurations.MaterialConfigurations.MaterialClasses;
using WMS.Infrastructure.EFConfigurations.MaterialConfigurations.MaterialLots;
using WMS.Infrastructure.EFConfigurations.PartyConfigurations.People;

namespace WMS.Infrastructure
{
    public class WMSDbContext : DbContext, IUnitOfWork
    {
        // Party Aggregate
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<PersonProperty> PersonProperties { get; set; }

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

        // Equipment Aggregate
        public DbSet<EquipmentClass> EquipmentClasses { get; set; }
        public DbSet<EquipmentClassProperty> EquipmentClassProperties { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<EquipmentProperty> EquipmentProperties { get; set; }

        // Inventory Receipt Aggregate
        public DbSet<InventoryReceipt> InventoryReceipts { get; set; }
        public DbSet<InventoryReceiptEntry> InventoryReceiptEntries { get; set; }
        public DbSet<ReceiptLot> ReceiptLots { get; set; }
        public DbSet<ReceiptSublot> ReceiptSublots { get; set; }

        // Inventory Issue Aggregate
        public DbSet<InventoryIssue> InventoryIssues { get; set; }
        public DbSet<InventoryIssueEntry> InventoryIssueEntries { get; set; }
        public DbSet<IssueLot> IssueLots { get; set; }
        public DbSet<IssueSublot> IssueSublots { get; set; }

        // InventoryLog Aggregate
        public DbSet<InventoryLog> InventoryLogs { get; set; }

        // MaterialLotAdjustment Aggregate
        public DbSet<MaterialLotAdjustment> MaterialLotAdjustments { get; set; }

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
            // party aggregate
            modelBuilder.ApplyConfiguration(new PersonEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PersonPropertyEntityTypeConfiguration());
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

            // equipment aggregate
            modelBuilder.ApplyConfiguration(new EquipmentClassEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EquipmentClassPropertyEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EquipmentEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EquipmentPropertyEntityTypeConfiguration());

            // inventory receipt aggregate
            modelBuilder.ApplyConfiguration(new InventoryReceiptEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new InventoryReceiptEntryEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ReceiptLotEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ReceiptSubLotEntityTypeConfiguration());

            // inventory issue aggregate
            modelBuilder.ApplyConfiguration(new InventoryIssueEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new InventoryIssueEntryEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new IssueLotEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new IssueSubLotEntityTypeConfiguration());

            // inventory Log aggregate
            modelBuilder.ApplyConfiguration(new InventoryLogEntityTypeConfiguration());

            // material lot adjustment aggregate
            modelBuilder.ApplyConfiguration(new MaterialLotAdjustmentEntityTypeConfiguration());

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
