namespace WMS.Infrastructure.EFConfigurations.PartyConfigurations
{
    public class SupplierEntityTypeConfiguration : IEntityTypeConfiguration<Supplier> 
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(b => b.supplierId);

            builder.Property(b => b.supplierName)
                .IsRequired();

            builder.Property(b => b.contactDetails)
                .IsRequired();

        }
    }
}
