namespace WMS.Infrastructure.EFConfigurations.InventoryLogConfigurations
{
    public class InventoryLogEntityTypeConfiguration : IEntityTypeConfiguration<InventoryLog>
    {
        public void Configure(EntityTypeBuilder<InventoryLog> builder)
        {
            builder.HasKey(s => s.inventoryLogId);

            builder.Property(s => s.transactionType)
                .HasConversion(
                    v => v.ToString(),
                    v => (TransactionType)Enum.Parse(typeof(TransactionType), v))
                .IsRequired();

            builder.Property(s => s.transactionDate)
                .IsRequired();

            builder.Property(s => s.previousQuantity)
                .IsRequired();

            builder.Property(s => s.changedQuantity)
                .IsRequired();

            builder.Property(s => s.afterQuantity)
                .IsRequired();

            builder.HasOne(s => s.materialLot)
                .WithMany(s => s.inventoryLogs)
                .HasForeignKey(s => s.lotNumber)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.warehouse)
                .WithMany(s => s.inventoryLogs)
                .HasForeignKey(s => s.warehouseId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
