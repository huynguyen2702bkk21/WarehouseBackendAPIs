namespace WMS.Infrastructure.EFConfigurations.InventoryIssueConfigurations
{
    public class IssueSubLotEntityTypeConfiguration : IEntityTypeConfiguration<IssueSublot>
    {
        public void Configure(EntityTypeBuilder<IssueSublot> builder)
        {

            builder.HasKey(s => s.issueSublotId);

            builder.Property(s => s.requestedQuantity)
                .IsRequired();

            builder.HasOne(s => s.materialSublot)
                .WithMany(s => s.issueSublots)
                .HasForeignKey(s => s.sublotId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.issueLot)
                .WithMany(s => s.issueSublots)
                .HasForeignKey(s => s.issueLotId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            
        }
    }
}
