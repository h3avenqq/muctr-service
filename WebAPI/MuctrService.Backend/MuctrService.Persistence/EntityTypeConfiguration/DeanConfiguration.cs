using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MuctrService.Domain;

namespace MuctrService.Persistence.EntityTypeConfiguration
{
    public class DeanConfiguration : IEntityTypeConfiguration<Dean>
    {
        public void Configure(EntityTypeBuilder<Dean> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();
            builder.Property(x => x.Surname).HasMaxLength(100);
            builder.Property(x => x.FirstName).HasMaxLength(100);
            builder.Property(x => x.SecondName).HasMaxLength(100);
            //builder.HasOne(x => x.Faculty).WithOne(x=>x.Dean).HasForeignKey(x=>x.);
        }
    }
}
