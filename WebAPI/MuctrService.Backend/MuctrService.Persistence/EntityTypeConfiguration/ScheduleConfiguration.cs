using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MuctrService.Domain;

namespace MuctrService.Persistence.EntityTypeConfiguration
{
    public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x=>x.Id).IsUnique();
            builder.Property(x => x.Name).HasMaxLength(250);
            builder.Property(x => x.Url).HasMaxLength(250);
            builder.HasOne(x => x.EducationType).WithMany(x => x.Schedules);
        }
    }
}
