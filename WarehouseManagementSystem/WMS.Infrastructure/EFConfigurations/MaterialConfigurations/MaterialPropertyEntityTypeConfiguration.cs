namespace WMS.Infrastructure.EFConfigurations.MaterialConfigurations
{
    public class MaterialPropertyEntityTypeConfiguration : IEntityTypeConfiguration<MaterialProperty>
    {
        public void Configure(EntityTypeBuilder<MaterialProperty> builder)
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

            builder.HasOne(b => b.material)
                .WithMany(b => b.porperties)
                .HasForeignKey(b => b.materialId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
