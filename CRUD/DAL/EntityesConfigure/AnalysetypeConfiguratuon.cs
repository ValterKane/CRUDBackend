using CRUD.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD.DAL.EntityesConfigure;

public class AnalysetypeConfiguratuon : IEntityTypeConfiguration<Analysetype>
{
    public void Configure(EntityTypeBuilder<Analysetype> builder)
    {
        // Mapping to table
        builder.ToTable("analysetype");
        // Mapping to prop
        builder.Property(p => p.Name).HasColumnName("name");
        builder.Property(p => p.Typeid).HasColumnName("type");
        // Keys configuration
        builder.HasKey(e => e.Typeid).HasName("analysetype_pkey");
    }
}
