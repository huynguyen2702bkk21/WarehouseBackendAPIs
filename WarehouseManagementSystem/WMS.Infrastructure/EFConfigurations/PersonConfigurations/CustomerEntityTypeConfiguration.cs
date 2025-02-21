namespace WMS.Infrastructure.EFConfigurations.PersonConfigurations
{
    public class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(b => b.customerId);

            builder.Property(b => b.customerName)
                .IsRequired();

            builder.Property(b => b.contactDetails)
                .IsRequired();

        }
    }
}
