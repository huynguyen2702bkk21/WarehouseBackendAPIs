namespace WMS.Infrastructure.EFConfigurations.InventoryIssueConfigurations
{
    public class IssueSubLotEntityTypeConfiguration : IEntityTypeConfiguration<IssueSublot>
    {
        public void Configure(EntityTypeBuilder<IssueSublot> builder)
        {

            builder.HasKey(s => s.issueSublotId);

            builder.Property(s => s.requestedQuantity)
                .IsRequired();

            builder.Property(s => s.subLotStatus)
                .HasConversion(
                    v => v.ToString(),
                    v => (LotStatus)Enum.Parse(typeof(LotStatus), v))
                .IsRequired();

            builder.Property(s => s.unitOfMeasure)
                .HasConversion(
                    v => v.ToString(),
                    v => (UnitOfMeasure)Enum.Parse(typeof(UnitOfMeasure), v))
                .IsRequired();

            builder.HasOne(s => s.location)
                .WithMany(s => s.issueSublots)
                .HasForeignKey(s => s.locationId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(s => s.issueLot)
                .WithMany(s => s.issueSublots)
                .HasForeignKey(s => s.issueLotId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            
        }
    }
}
