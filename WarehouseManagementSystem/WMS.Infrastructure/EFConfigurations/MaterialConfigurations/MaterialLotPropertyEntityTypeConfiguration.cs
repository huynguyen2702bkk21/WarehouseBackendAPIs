namespace WMS.Infrastructure.EFConfigurations.MaterialConfigurations
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

            builder.HasOne(s => s.materialLot)
                .WithMany(s => s.properties)
                .HasForeignKey(s => s.lotNumber)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
    
}
