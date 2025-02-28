namespace WMS.Infrastructure.EFConfigurations.InventoryReceiptConfigurations
{
    public class ReceiptSubLotEntityTypeConfiguration : IEntityTypeConfiguration<ReceiptSublot>
    {
        public void Configure(EntityTypeBuilder<ReceiptSublot> builder)
        {

            builder.HasKey(s => s.receiptSublotId);

            builder.Property(s => s.importedQuantity)
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
                .WithMany(s => s.receiptSublots)
                .HasForeignKey(s => s.locationId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.receiptLot)
                .WithMany(s => s.receiptSublots)
                .HasForeignKey(s => s.receiptLotId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
