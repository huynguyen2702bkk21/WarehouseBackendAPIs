namespace WMS.Infrastructure.EFConfigurations.MaterialConfigurations
{
    public class MaterialLotEntityTypeConfiguration : IEntityTypeConfiguration<MaterialLot> 
    {
        public void Configure(EntityTypeBuilder<MaterialLot> builder)
        {
            builder.HasKey(b => b.lotNumber);

            builder.Property(s => s.lotStatus)
                .HasConversion(
                    v => v.ToString(),
                    v => (LotStatus)Enum.Parse(typeof(LotStatus), v))
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(s => s.exisitingQuantity)
                .IsRequired();

            builder.HasOne(s => s.material)
                .WithMany(s => s.lots)
                .HasForeignKey(s => s.materialId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);




        }
    }
}
