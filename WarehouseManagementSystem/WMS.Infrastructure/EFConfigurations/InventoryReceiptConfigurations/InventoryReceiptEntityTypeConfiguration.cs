namespace WMS.Infrastructure.EFConfigurations.InventoryReceiptConfigurations
{
    public class InventoryReceiptEntityTypeConfiguration : IEntityTypeConfiguration<InventoryReceipt>
    {
        public void Configure(EntityTypeBuilder<InventoryReceipt> builder)
        {
            builder.HasKey(s => s.inventoryReceiptId);

            builder.Property(s => s.receiptDate)
                .IsRequired();

            builder.Property(s => s.receiptStatus)
                .HasConversion(
                    v => v.ToString(),
                    v => (ReceiptStatus)Enum.Parse(typeof(ReceiptStatus), v))
                .IsRequired();
            
            builder.HasOne(s => s.supplier)
                .WithMany(s => s.inventoryReceipts)
                .HasForeignKey(s => s.supplierId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.receivedBy)
                .WithMany(s => s.inventoryReceipts)
                .HasForeignKey(s => s.personId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.warehouse)
                .WithMany(s => s.inventoryReceipts)
                .HasForeignKey(s => s.warehouseId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
