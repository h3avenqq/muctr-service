using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MuctrService.Domain;

namespace MuctrService.Persistence.EntityTypeConfiguration
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();
            builder.Property(x => x.Name).HasMaxLength(250);
            builder.HasOne(f => f.Faculty).WithMany(d => d.Departments);
            builder.HasMany(f => f.Professors).WithOne(d => d.Department);
        }
    }
}
