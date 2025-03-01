namespace WMS.Infrastructure.EFConfigurations.EquipmentConfigurations
{
    public class EquipmentEntityTypeConfiguration : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder.HasKey(b => b.equipmentId);

            builder.Property(b => b.equipmentName)
                .IsRequired();

            builder.HasOne(s => s.equipmentClass)
                .WithMany(s => s.equipments)
                .HasForeignKey(s => s.equipmentClassId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

        }

    }
}
