using CRUD.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD.DAL.EntityesConfigure;

public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        // Mapping to table
        builder.ToTable("doctors");
        // Mapping to prop
        builder.Property(p => p.Docuuid).HasColumnName("docuuid").ValueGeneratedNever();
        builder.Property(p => p.Licence).HasColumnName("licence");
        builder.Property(p => p.Specid).HasColumnName("specid");
        // Keys configuration
        builder.HasKey(e => e.Docuuid).HasName("doctors_pkey");
        builder.HasOne(d => d.Docuu).WithOne(p => p.Doctor).OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("doctors_docuuid_fkey");
        builder.HasOne(d => d.Spec).WithMany((p => p.Doctors)).HasConstraintName("doctors_specid_fkey");
    }
}
