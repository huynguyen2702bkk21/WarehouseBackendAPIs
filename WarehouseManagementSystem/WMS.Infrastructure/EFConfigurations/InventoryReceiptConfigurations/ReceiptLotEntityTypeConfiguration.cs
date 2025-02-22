namespace WMS.Infrastructure.EFConfigurations.InventoryReceiptConfigurations
{
    public class ReceiptLotEntityTypeConfiguration : IEntityTypeConfiguration<ReceiptLot>
    {
        public void Configure(EntityTypeBuilder<ReceiptLot> builder)
        {
            builder.HasKey(s => s.receiptLotId);

            builder.Property(s => s.importedQuantity)
                .IsRequired();

            builder.Property(s => s.lotStatus)
                .HasConversion(
                    v => v.ToString(),
                    v => (LotStatus)Enum.Parse(typeof(LotStatus), v))
                .IsRequired();

            builder.HasOne(s => s.inventoryReceiptEntry)
                .WithOne(s => s.receiptLot)
                .HasForeignKey<ReceiptLot>(s => s.InventoryReceiptEntryId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
