namespace WMS.Infrastructure.EFConfigurations.InventoryIssueConfigurations
{
    public class InventoryIssueEntryEntityTypeConfiguration : IEntityTypeConfiguration<InventoryIssueEntry>
    {
        public void Configure(EntityTypeBuilder<InventoryIssueEntry> builder)
        {
            builder.HasKey(s => s.inventoryIssueEntryId);
            
            builder.Property(s => s.purchaseOrderNumber)
                .IsRequired();

            builder.Property(s => s.note)
                .HasMaxLength(500);

            builder.Property(s => s.requestedQuantity)
                .IsRequired();

            builder.HasOne(s => s.material)
                .WithMany(s => s.issueEntries)
                .HasForeignKey(s => s.materialId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(s => s.inventoryIssue)
                .WithMany(s => s.entries)
                .HasForeignKey(s => s.inventoryIssueId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(s => s.issueLot)
                .WithOne(s => s.inventoryIssueEntry)
                .HasForeignKey<InventoryIssueEntry>(s => s.issueLotId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
