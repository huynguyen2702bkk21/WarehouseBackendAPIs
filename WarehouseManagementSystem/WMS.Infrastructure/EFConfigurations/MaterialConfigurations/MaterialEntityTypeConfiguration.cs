namespace WMS.Infrastructure.EFConfigurations.MaterialConfigurations
{
    public class MaterialEntityTypeConfiguration : IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> builder)
        {
            builder.HasKey(b => b.materialId);

            builder.Property(b => b.materialName)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(s => s.materialClass)
                .WithMany(s => s.materials  )
                .HasForeignKey(s => s.materialClassId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
