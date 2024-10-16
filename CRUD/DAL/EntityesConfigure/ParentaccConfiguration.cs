using CRUD.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD.DAL.EntityesConfigure;

public class ParentaccConfiguration : IEntityTypeConfiguration<Parentacc>
{
    public void Configure(EntityTypeBuilder<Parentacc> builder)
    {
        // Mapping to table
        builder.ToTable("parentacc");
        // Mapping to prop
        builder.Property(p => p.Paruuid).HasColumnName("paruuid").HasColumnType("uuid").ValueGeneratedNever();
        builder.Property(p => p.Login).HasColumnName("login");
        builder.Property(p => p.HashPass).HasColumnName("hashpass");
        builder.Property(p => p.Status).HasColumnName("status");
        //Keys configuration
        builder.HasKey(e => e.Login).HasName("parentacc_pkey");
        builder.HasOne(d => d.Paruu).WithOne(p => p.Parentacc)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("parentacc_paruuid_fkey");

        builder.HasIndex(I => I.Paruuid).IsUnique().HasDatabaseName("parentacc_paruuid_key");
    }
}
