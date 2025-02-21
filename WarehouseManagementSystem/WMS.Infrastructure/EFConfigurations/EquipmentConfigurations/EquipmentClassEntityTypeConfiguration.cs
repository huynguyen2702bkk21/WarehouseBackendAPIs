namespace WMS.Infrastructure.EFConfigurations.EquipmentConfigurations
{
    public class EquipmentClassEntityTypeConfiguration : IEntityTypeConfiguration<EquipmentClass>
    {
        public void Configure(EntityTypeBuilder<EquipmentClass> builder)
        {
            builder.HasKey(b => b.equipmentClassId);

            builder.Property(b => b.className)
                .IsRequired();

        }
    }
    
}
