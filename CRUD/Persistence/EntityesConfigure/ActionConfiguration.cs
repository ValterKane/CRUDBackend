using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Action = CRUD.DAL.Entities.Action;
namespace CRUD.Persistence.EntityesConfigure;

public class ActionConfiguration : IEntityTypeConfiguration<Action>
{
    public void Configure(EntityTypeBuilder<Action> builder)
    {
        // Mapping to table
        builder.ToTable("actions");
        // Mapping to prop
        builder.Property(e => e.Actuuid).HasColumnName("actuuid").ValueGeneratedNever();
        builder.Property(p => p.Schedule).HasColumnName("schedule").HasColumnType("json");
        builder.Property(p => p.Name).HasColumnName("name");
        builder.Property(p => p.Typeid).HasColumnName("type").ValueGeneratedNever();
        // Keys configuration
        builder.HasKey(p => p.Actuuid).HasName("actions_pkey");
        builder.HasOne(d => d.ActionType).WithMany(p => p.Actions).HasForeignKey(k=>k.Typeid)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("actions_type_fkey");
    }
}