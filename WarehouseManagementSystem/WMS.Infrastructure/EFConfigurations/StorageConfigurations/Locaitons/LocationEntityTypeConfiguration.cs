namespace WMS.Infrastructure.EFConfigurations.StorageConfigurations
{
    public class LocationEntityTypeConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(b => b.locationId);

            builder.HasOne(b => b.warehouse)
                .WithMany(b => b.locations)
                .HasForeignKey(b => b.warehouseId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
