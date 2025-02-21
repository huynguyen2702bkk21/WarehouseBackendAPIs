namespace WMS.Infrastructure.EFConfigurations.EquipmentConfigurations
{
    public class EquipmentPropertyEntityTypeConfiguration : IEntityTypeConfiguration<EquipmentProperty>
    {
        public void Configure(EntityTypeBuilder<EquipmentProperty> builder)
        {
            builder.HasKey(b => b.propertyId);

            builder.Property(b => b.propertyName)
                .IsRequired();

            builder.Property(b => b.propertyValue)
                .IsRequired();

            builder.Property(b => b.unitOfMeasure)
                .HasConversion(
                    v => v.ToString(),
                    v => (UnitOfMeasure)Enum.Parse(typeof(UnitOfMeasure), v))
                .HasMaxLength(50)
                .IsRequired();

            builder.HasOne(b => b.equipment)
                .WithMany(b => b.properties)
                .HasForeignKey(b => b.equipmentId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
    
}
