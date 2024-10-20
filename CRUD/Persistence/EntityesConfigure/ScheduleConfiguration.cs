using CRUD.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD.Persistence.EntityesConfigure;

public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
{
    public void Configure(EntityTypeBuilder<Schedule> builder)
    {
        // Mapping to table
        builder.ToTable("schedule");
        // Mapping to prop
        builder.Property(p => p.Timemark).HasColumnName("timemark").HasColumnType("timestamp without time zone");
        builder.Property(p => p.Actuuid).HasColumnName("actuuid");
        builder.Property(p => p.Chuuid).HasColumnName("chuuid");
        builder.Property(p => p.Place).HasColumnName("place");
        //Keys configuration
        builder.HasKey(e => e.Timemark).HasName("schedule_pkey");

        builder.HasOne(d => d.Actuu).WithMany(p => p.Schedules).HasForeignKey(k => k.Actuuid)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("schedule_actuuid_fkey");

        builder.HasOne(d => d.Chuu).WithMany(p => p.Schedules).HasForeignKey(k => k.Chuuid)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("schedule_chuuid_fkey");
    }
}
