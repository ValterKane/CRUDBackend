using CRUD.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD.Persistence.EntityesConfigure;

public class DocspecConfiguration : IEntityTypeConfiguration<Docspec>
{
    public void Configure(EntityTypeBuilder<Docspec> builder)
    {
        // Mapping to table
        builder.ToTable("docspec");
        // Mapping to prop
        builder.Property(p => p.Specid).HasColumnName("specid").ValueGeneratedNever();
        builder.Property(p => p.Specname).HasColumnName("specname");
        // Keys configuration
        builder.HasKey(e => e.Specid).HasName("docspec_pkey");
    }
}
