namespace WMS.Infrastructure.EFConfigurations.PersonConfigurations
{
    public class EmployeeEntityTypeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(b => b.employeeId);

            builder.Property(b => b.employeeName)
                .IsRequired();

            builder.Property(b => b.role)
                .IsRequired();
        }
    }
}
