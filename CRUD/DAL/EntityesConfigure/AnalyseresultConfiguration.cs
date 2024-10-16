using CRUD.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD.DAL.EntityesConfigure;

public class AnalyseresultConfiguration : IEntityTypeConfiguration<Analyseresult>
{
    public void Configure(EntityTypeBuilder<Analyseresult> builder)
    {
        // Mapping to table
        builder.ToTable("analyseresult");
        // Mapping to prop
        builder.Property(p => p.Resid).HasColumnName("resid");
        builder.Property(p => p.Empluuid).HasColumnName("empluuid");
        builder.Property(p => p.Analystype).HasColumnName("analystype");
        builder.Property(p => p.Resultcomment).HasColumnName("resultcomment");
        builder.Property(p => p.Result).HasColumnName("result").HasColumnType("json");
        //Keys configuration
        builder.HasKey(e => e.Resid).HasName("analyseresult_pkey");
        builder.HasOne(d => d.AnalystypeNavigation).WithMany(p => p.Analyseresults)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("analyseresult_analystype_fkey");
        builder.HasOne(d => d.Empluu).WithMany(p => p.Analyseresults)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("analyseresult_empluuid_fkey");
    }
}
