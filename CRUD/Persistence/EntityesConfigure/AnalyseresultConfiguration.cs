using CRUD.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD.Persistence.EntityesConfigure;

public class AnalyseresultConfiguration : IEntityTypeConfiguration<Analyseresult>
{
    public void Configure(EntityTypeBuilder<Analyseresult> builder)
    {
        // Mapping to table
        builder.ToTable("analyseresult");
        // Mapping to prop
        builder.Property(p => p.Resid).HasColumnName("resid");
        builder.Property(p => p.Empluuid).HasColumnName("empluuid");
        builder.Property(p => p.TypeOfAnalyse).HasColumnName("analystype");
        builder.Property(p => p.Resultcomment).HasColumnName("resultcomment");
        builder.Property(p => p.Result).HasColumnName("result").HasColumnType("json");
        //Keys configuration
        builder.HasKey(e => e.Resid).HasName("analyseresult_pkey");

        builder.HasOne(d => d.Analysetype).WithMany(p => p.Analyseresults).HasForeignKey(p => p.TypeOfAnalyse)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("analyseresult_analystype_fkey");

        builder.HasOne(d => d.Empluu).WithMany(p => p.Analyseresults).HasForeignKey(k => k.Empluuid)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("analyseresult_empluuid_fkey");
    }
}
