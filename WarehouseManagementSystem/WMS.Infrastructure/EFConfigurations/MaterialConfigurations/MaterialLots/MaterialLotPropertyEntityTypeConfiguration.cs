namespace WMS.Infrastructure.EFConfigurations.MaterialConfigurations.MaterialLots
{
    public class MaterialLotPropertyEntityTypeConfiguration : IEntityTypeConfiguration<MaterialLotProperty>
    {
        public void Configure(EntityTypeBuilder<MaterialLotProperty> builder)
        {
            builder.HasKey(b => b.propertyId);

            builder.Property(b => b.propertyName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(b => b.propertyValue)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(b => b.unitOfMeasure)
                .HasConversion(
                    v => v.ToString(),
                    v => (UnitOfMeasure)Enum.Parse(typeof(UnitOfMeasure), v))
                .IsRequired();

            builder.HasOne(s => s.materialLot)
                .WithMany(s => s.properties)
                .HasForeignKey(s => s.lotNumber)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
