namespace WMS.Infrastructure.EFConfigurations.MaterialConfigurations
{
    public class MaterialSubLotEntityTypeConfiguration : IEntityTypeConfiguration<MaterialSubLot>
    {
        public void Configure(EntityTypeBuilder<MaterialSubLot> builder)
        {
            builder.HasKey(b => b.subLotId);

            builder.Property(s => s.subLotStatus)
                .HasConversion(
                    v => v.ToString(),
                    v => (LotStatus)Enum.Parse(typeof(LotStatus), v))
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(s => s.existingQuality)
                .IsRequired();

            builder.Property(s => s.unitOfMeasure)
                .HasConversion(
                    v => v.ToString(),
                    v => (UnitOfMeasure)Enum.Parse(typeof(UnitOfMeasure), v))
                .HasMaxLength(50)
                .IsRequired();

            builder.HasOne(s => s.materialLot)
                .WithMany(s => s.subLots)
                .HasForeignKey(s => s.lotNumber)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.location)
                .WithMany(s => s.materialSubLots)
                .HasForeignKey(s => s.locationId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
