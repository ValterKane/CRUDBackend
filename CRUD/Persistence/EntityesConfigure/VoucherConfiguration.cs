using CRUD.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD.Persistence.EntityesConfigure;

public class VoucherConfiguration : IEntityTypeConfiguration<Voucher>
{
    public void Configure(EntityTypeBuilder<Voucher> builder)
    {
        // Mapping to table
        builder.ToTable("voucher");
        // Mapping to prop
        builder.Property(p => p.Void).HasColumnName("void");
        builder.Property(p => p.Paruuid).HasColumnName("paruuid").HasColumnType("uuid");
        builder.Property(p => p.Checkin).HasColumnName("checkin").HasColumnType("timestamp without time zone");
        builder.Property(p => p.Checkout).HasColumnName("checkout").HasColumnType("timestamp without time zone");
        builder.Property(p => p.Sourcevo).HasColumnName("sourcevo");
        //Keys configuration
        builder.HasKey(e => e.Void).HasName("voucher_pkey");

        builder.HasOne(d => d.Paruu).WithMany(p => p.Vouchers).HasForeignKey(k => k.Paruuid)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("voucher_paruuid_fkey");
    }
}
