using CRUD.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD.DAL.EntityesConfigure;

public class ActiontypeConfuguration : IEntityTypeConfiguration<Actiontype>
{
    public void Configure(EntityTypeBuilder<Actiontype> builder)
    {
        //Mapping to table
        builder.ToTable("actiontype");
        //Mapping to prop
        builder.Property(p => p.TypeId).HasColumnName("typeid");
        builder.Property(p => p.Name).HasColumnName("name");
        //Keys configuration
        builder.HasKey(e => e.TypeId).HasName("actiontype_pkey");
    }
}
