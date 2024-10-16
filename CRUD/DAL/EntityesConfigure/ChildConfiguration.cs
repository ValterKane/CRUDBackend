using CRUD.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD.DAL.EntityesConfigure;

public class ChildConfiguration : IEntityTypeConfiguration<Child>
{
    public void Configure(EntityTypeBuilder<Child> builder)
    {
        // Mapping to table
        builder.ToTable("child");
        // Mapping to prop
        builder.Property(p => p.Chuuid).HasColumnName("chuuid").HasColumnType("uuid").ValueGeneratedNever();
        builder.Property(p => p.Firstname).HasColumnName("firstname");
        builder.Property(p => p.Secondname).HasColumnName("secondname");
        builder.Property(p => p.Lastname).HasColumnName("lastname");
        builder.Property(p => p.Age).HasColumnName("age").HasDefaultValue(7);
        // Keys configuration
        builder.HasKey(e => e.Chuuid).HasName("child_pkey");
    }
}
