namespace WMS.Infrastructure.EFConfigurations.MaterialConfigurations
{
    public class MaterialClassPropertyEntityTypeConfiguration : IEntityTypeConfiguration<MaterialClassProperty>
    {
        public void Configure(EntityTypeBuilder<MaterialClassProperty> builder)
        {
            builder.HasKey(b => b.propertyId);

            builder.Property(b => b.propertyName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(b => b.propertyValue)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(s => s.unitOfMeasure)
                .HasConversion(
                    v => v.ToString(),
                    v => (UnitOfMeasure)Enum.Parse(typeof(UnitOfMeasure), v))
                .HasMaxLength(50)
                .IsRequired();

            builder.HasOne(b => b.materialClass)
                .WithMany(b => b.properties)
                .HasForeignKey(b => b.materialClassId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

        }
    }

}
