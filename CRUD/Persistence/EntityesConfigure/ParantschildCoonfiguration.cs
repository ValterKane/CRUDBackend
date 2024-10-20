using CRUD.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD.Persistence.EntityesConfigure;

public class ParantschildCoonfiguration : IEntityTypeConfiguration<Parantschild>
{
    public void Configure(EntityTypeBuilder<Parantschild> builder)
    {
        // Mapping to table
        builder.ToTable("parantschild");
        // Mapping to prop
        builder.Property(p => p.Chuuid).HasColumnName("chuuid").HasColumnType("uuid");
        builder.Property(p => p.Paruuid).HasColumnName("paruuid").HasColumnType("uuid");
        builder.Property(p => p.Kinship).HasColumnName("kinship");
        // Keys configuration
        builder.HasKey(e => new { chuuid = e.Chuuid, paruuid = e.Paruuid }).HasName("parantschild_pkey");
        
        builder.HasIndex(i => i.Chuuid).IsUnique().HasDatabaseName("parantschild_chuuid_key");
        builder.HasIndex(i => i.Paruuid).IsUnique().HasDatabaseName("parantschild_paruuid_key");

        builder.HasOne(d => d.Chuu).WithOne(p => p.Parantschild)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("parantschild_chuuid_fkey");

        builder.HasOne(d => d.Paruu).WithOne(p => p.Parantschild)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("parantschild_paruuid_fkey");
    }
}
