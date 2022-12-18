using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MuctrService.Domain;

namespace MuctrService.Persistence.EntityTypeConfiguration
{
    public class EducationTypeConfiguration : IEntityTypeConfiguration<EducationType>
    {
        public void Configure(EntityTypeBuilder<EducationType> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();
            builder.Property(x => x.Name).HasMaxLength(250);
            builder.HasMany(x => x.Schedules).WithOne(x => x.EducationType);
        }
    }
}
