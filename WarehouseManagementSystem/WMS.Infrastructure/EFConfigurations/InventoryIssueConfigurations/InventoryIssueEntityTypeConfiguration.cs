namespace WMS.Infrastructure.EFConfigurations.InventoryIssueConfigurations
{
    public class InventoryIssueEntityTypeConfiguration : IEntityTypeConfiguration<InventoryIssue>
    {
        public void Configure(EntityTypeBuilder<InventoryIssue> builder)
        {
            builder.HasKey(s => s.inventoryIssueId);
            
            builder.Property(s => s.issueDate)
                .IsRequired();

            builder.Property(s => s.issueStatus)
                .HasConversion(
                    v => v.ToString(),
                    v => (IssueStatus)Enum.Parse(typeof(IssueStatus), v))
                .IsRequired();

            builder.HasOne(s => s.warehouse)
                .WithMany(s => s.inventoryIssues)
                .HasForeignKey(s => s.warehouseId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.issuedBy)
                .WithMany(s => s.inventoryIssues)
                .HasForeignKey(s => s.personId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.customer)
                .WithMany(s => s.inventoryIssues)
                .HasForeignKey(s => s.customerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
