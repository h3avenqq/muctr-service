using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MuctrService.Domain;

namespace MuctrService.Persistence.EntityTypeConfiguration
{
    public class StudentsInfoConfiguration : IEntityTypeConfiguration<StudentsInfo>
    {
        public void Configure(EntityTypeBuilder<StudentsInfo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();
            builder.Property(x => x.Name).HasMaxLength(250);
        }
    }
}
