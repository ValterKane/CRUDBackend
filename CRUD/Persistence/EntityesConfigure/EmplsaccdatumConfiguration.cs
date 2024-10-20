using CRUD.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD.Persistence.EntityesConfigure;

public class EmplsaccdatumConfiguration : IEntityTypeConfiguration<Emplsaccdatum>
{
    public void Configure(EntityTypeBuilder<Emplsaccdatum> builder)
    {
        // Mapping to table
        builder.ToTable("emplsaccdata");
        // Mapping to prop
        builder.Property(p => p.Empluuid).HasColumnName("empluuid").HasColumnType("uuid");
        builder.Property(p => p.Login).HasColumnName("login");
        builder.Property(p => p.HashPassword).HasColumnName("hashpassword");
        builder.Property(p => p.Role).HasColumnName("role");
        // Keys configuration
        builder.HasKey(k => k.Empluuid).HasName("emplsaccdata_pkey");

        builder.HasOne(d => d.Empluu).WithOne(p => p.Emplsaccdatum).OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("emplsaccdata_empluuid_fkey");

        builder.HasIndex(p => p.Empluuid).IsUnique().HasDatabaseName("emplsaccdata_empluuid_key");
    }
}
