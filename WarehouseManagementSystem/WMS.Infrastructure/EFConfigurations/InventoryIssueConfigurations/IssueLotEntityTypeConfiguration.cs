namespace WMS.Infrastructure.EFConfigurations.InventoryIssueConfigurations
{
    public class IssueLotEntityTypeConfiguration : IEntityTypeConfiguration<IssueLot>
    {
        public void Configure(EntityTypeBuilder<IssueLot> builder)
        {
            builder.HasKey(s => s.issueLotId);

            builder.Property(s => s.requestedQuantity)
                .IsRequired();
            
            builder.Property(s => s.lotStatus)
                .HasConversion(
                    v => v.ToString(),
                    v => (LotStatus)Enum.Parse(typeof(LotStatus), v))
                .IsRequired();

            builder.HasOne(s => s.material)
                .WithMany(s => s.issueLots)
                .HasForeignKey(s => s.materialId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(s => s.inventoryIssueEntry)
                .WithOne(s => s.issueLot)
                .HasForeignKey<IssueLot>(s => s.inventoryIssueEntryId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
