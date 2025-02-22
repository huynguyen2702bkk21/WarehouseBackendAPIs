namespace WMS.Infrastructure.EFConfigurations.MaterialLotAdjustmentConfigurations
{
    public class MaterialLotAdjustmentEntityTypeConfiguration : IEntityTypeConfiguration<MaterialLotAdjustment>
    {
        public void Configure (EntityTypeBuilder<MaterialLotAdjustment> builder)
        {
            builder.HasKey(s => s.materialLotAdjustmentId);

            builder.Property(s => s.adjustmentDate)
                .IsRequired();

            builder.Property(s => s.previousQuantity)
                .IsRequired();

            builder.Property(s => s.adjustedQuantity)
                .IsRequired();

            builder.Property(s => s.reason)
                .HasConversion(
                    v => v.ToString(),
                    v => (AdjustmentReason)Enum.Parse(typeof(AdjustmentReason), v))
                .IsRequired();

            builder.Property(s => s.status)
                .HasConversion(
                    v => v.ToString(),
                    v => (AdjustmentStatus)Enum.Parse(typeof(AdjustmentStatus), v))
                .IsRequired();

            builder.HasOne(s => s.materialLot)
                .WithMany(s => s.materialLotAdjustments)
                .HasForeignKey(s => s.lotNumber)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.warehouse)
                .WithMany(s => s.materialLotAdjustments)
                .HasForeignKey(s => s.warehouseId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.adjustedBy)
                .WithMany(s => s.materialLotAdjustments)
                .HasForeignKey(s => s.employeeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            
        }
    }
}
