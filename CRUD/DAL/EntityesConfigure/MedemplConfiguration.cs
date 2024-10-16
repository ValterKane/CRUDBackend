using CRUD.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD.DAL.EntityesConfigure;

public class MedemplConfiguration : IEntityTypeConfiguration<Medempl>
{
    public void Configure(EntityTypeBuilder<Medempl> builder)
    {
        // Mapping to table
        builder.ToTable("medempls");
        // Mapping to prop
        builder.Property(p => p.Empluuid).HasColumnName("empluuid").ValueGeneratedNever();
        builder.Property(p => p.Firstname).HasColumnName("firstname");
        builder.Property(p => p.Secondname).HasColumnName("secondname");
        builder.Property(p => p.Lastname).HasColumnName("lastname");
        builder.Property(p => p.Catid).HasColumnName("catid");
        // Keys configuration
        builder.HasKey(e => e.Empluuid).HasName("medempls_pkey");
        builder.HasOne(d => d.Cat).WithMany(p => p.Medempls)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("medempls_catid_fkey");
    }
}
