using CRUD.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD.DAL.EntityesConfigure;

public class ParentConfiguration : IEntityTypeConfiguration<Parent>
{
    public void Configure(EntityTypeBuilder<Parent> builder)
    {
        // Mapping to table
        builder.ToTable("parents");
        // Mapping to prop
        builder.Property(p => p.Paruuid).HasColumnName("paruuid").HasColumnType("uuid").ValueGeneratedNever();
        builder.Property(p => p.Firstname).HasColumnName("firstname");
        builder.Property(p => p.Secondname).HasColumnName("secondname");
        builder.Property(p => p.Lastname).HasColumnName("lastname");
        builder.Property(p => p.Age).HasColumnName("age").ValueGeneratedNever().HasDefaultValue(18);
        builder.Property(p => p.Email).HasColumnName("email");
        builder.Property(p => p.Phonenumber).HasColumnName("phonenumber");
        //Keys configuration
        builder.HasKey(e => e.Paruuid).HasName("parents_pkey");
    }
}
