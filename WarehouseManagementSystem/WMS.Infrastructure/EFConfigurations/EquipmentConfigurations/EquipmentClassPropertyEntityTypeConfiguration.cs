namespace WMS.Infrastructure.EFConfigurations.EquipmentConfigurations
{
    public class EquipmentClassPropertyEntityTypeConfiguration : IEntityTypeConfiguration<EquipmentClassProperty>
    {
        public void Configure(EntityTypeBuilder<EquipmentClassProperty> builder)
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

            builder.HasOne(b => b.equipmentClass)
                .WithMany(b => b.properties)
                .HasForeignKey(b => b.equipmentClassId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
  
        }
    }
}
