namespace WMS.Infrastructure.EFConfigurations.StorageConfigurations
{
    public class WarehouseEntityTypeConfiguration : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            builder.HasKey(b => b.warehouseId);

            builder.Property(b => b.warehouseName)
                .IsRequired();

        }
    }
}
