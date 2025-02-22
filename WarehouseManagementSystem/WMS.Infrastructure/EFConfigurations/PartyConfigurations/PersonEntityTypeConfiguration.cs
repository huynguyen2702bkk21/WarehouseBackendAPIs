namespace WMS.Infrastructure.EFConfigurations.PartyConfigurations
{
    public class PersonEntityTypeConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(b => b.personId);

            builder.Property(b => b.personName)
                .IsRequired();

            builder.Property(b => b.role)
                .HasConversion(
                    v => v.ToString(),                  
                    v => (EmployeeType)Enum.Parse(typeof(EmployeeType), v))
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
