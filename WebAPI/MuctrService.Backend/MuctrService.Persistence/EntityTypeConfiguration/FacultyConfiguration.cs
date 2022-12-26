using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MuctrService.Domain;

namespace MuctrService.Persistence.EntityTypeConfiguration
{
    public class FacultyConfiguration : IEntityTypeConfiguration<Faculty>
    {
        public void Configure(EntityTypeBuilder<Faculty> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();
            builder.Property(x => x.Name).HasMaxLength(250);
            builder.HasMany(d => d.Departments).WithOne(f => f.Faculty);
            builder.HasOne(x => x.Dean).WithOne(x=>x.Faculty).HasForeignKey<Dean>(x=>x.FacultyId);
        }
    }
}
