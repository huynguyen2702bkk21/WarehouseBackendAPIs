namespace WMS.Infrastructure.EFConfigurations.MaterialConfigurations
{
    public class MaterialClassEntityTypeConfiguration : IEntityTypeConfiguration<MaterialClass>
    {
        public void Configure(EntityTypeBuilder<MaterialClass> builder)
        {
            builder.HasKey(b => b.materialClassId);

            builder.Property(b => b.className)
                .IsRequired()
                .HasMaxLength(50);
        }
    }

}
