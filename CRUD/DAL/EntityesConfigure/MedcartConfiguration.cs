using CRUD.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD.DAL.EntityesConfigure;

public class MedcartConfiguration : IEntityTypeConfiguration<Medcart>
{
    public void Configure(EntityTypeBuilder<Medcart> builder)
    {
        // Mapping to table
        builder.ToTable("medcart");
        // Mapping to prop
        builder.Property(p => p.Timemark).HasColumnName("timemark").HasColumnType("timestamp without time zone");
        builder.Property(p => p.Chuuid).HasColumnName("chuuid");
        builder.Property(p => p.Textresult).HasColumnName("textresult");
        builder.Property(p => p.Docuuid).HasColumnName("docuuid");
        // Keys configuration
        builder.HasKey(e => new { timemark = e.Timemark, chuuid = e.Chuuid }).HasName("medcart_pkey");

        builder.HasOne(d => d.Chuu).WithMany(p => p.Medcarts).HasForeignKey(k => k.Chuuid)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("medcart_chuuid_fkey");

        builder.HasOne(d => d.Docuu).WithMany(p => p.Medcarts).HasForeignKey(k => k.Docuuid)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("medcart_docuuid_fkey");
    }
}
