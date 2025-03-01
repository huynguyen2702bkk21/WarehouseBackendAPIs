namespace WMS.Infrastructure.EFConfigurations.InventoryIssueConfigurations
{
    public class IssueLotEntityTypeConfiguration : IEntityTypeConfiguration<IssueLot>
    {
        public void Configure(EntityTypeBuilder<IssueLot> builder)
        {
            builder.HasKey(s => s.issueLotId);

            builder.Property(s => s.requestedQuantity)
                .IsRequired();
            
            builder.Property(s => s.issueLotStatus)
                .HasConversion(
                    v => v.ToString(),
                    v => (LotStatus)Enum.Parse(typeof(LotStatus), v))
                .IsRequired();
            
            builder.HasOne(s => s.materialLot)
                .WithMany(s => s.issueLots)
                .HasForeignKey(s => s.materialLotId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.inventoryIssueEntry)
                .WithOne(s => s.issueLot)
                .HasForeignKey<IssueLot>(s => s.inventoryIssueEntryId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            

        }
    }
}
