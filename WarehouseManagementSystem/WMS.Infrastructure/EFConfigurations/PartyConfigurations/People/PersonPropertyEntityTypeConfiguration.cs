namespace WMS.Infrastructure.EFConfigurations.PartyConfigurations.People
{
    public class PersonPropertyEntityTypeConfiguration : IEntityTypeConfiguration<PersonProperty>
    {
        public void Configure(EntityTypeBuilder<PersonProperty> builder)
        {
            builder.HasKey(s => s.propertyId);

            builder.Property(s => s.propertyName)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(s => s.person)
                .WithMany(s => s.properties)
                .HasForeignKey(s => s.personId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);




        }


    }
}
