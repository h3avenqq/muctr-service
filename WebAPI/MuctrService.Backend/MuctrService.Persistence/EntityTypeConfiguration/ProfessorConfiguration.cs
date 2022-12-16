using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MuctrService.Domain;


namespace MuctrService.Persistence.EntityTypeConfiguration
{
    public class ProfessorConfiguration : IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();
            builder.Property(x => x.Surname).HasMaxLength(100);
            builder.Property(x=>x.FirstName).HasMaxLength(100);
            builder.Property(x => x.SecondName).HasMaxLength(100);
            builder.HasOne(x => x.Department).WithMany(x => x.Professors);
            builder.Property(x => x.Position).HasMaxLength(250);
            //мб сюда как то можно перенести настройку мобилки и почты хз
        }
    }
}
