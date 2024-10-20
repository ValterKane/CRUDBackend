using CRUD.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD.Persistence.EntityesConfigure;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        // Mapping to table
        builder.ToTable("category");
        // Mapping to prop
        builder.Property(p => p.Catid).HasColumnName("catid").ValueGeneratedNever();
        builder.Property(p => p.Catname).HasColumnName("catname");
        // Keys configuration
        builder.HasKey(p => p.Catid).HasName("category_pkey");
    }
}
