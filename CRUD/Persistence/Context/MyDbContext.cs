using System.Reflection;
using CRUD.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Action = CRUD.DAL.Entities.Action;

namespace CRUD.DAL.Context;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Action> Actions { get; set; }

    public virtual DbSet<Actiontype> Actiontypes { get; set; }

    public virtual DbSet<Analyseresult> Analyseresults { get; set; }

    public virtual DbSet<Analysetype> Analysetypes { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Child> Children { get; set; }

    public virtual DbSet<Docspec> Docspecs { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Emplsaccdatum> Emplsaccdata { get; set; }

    public virtual DbSet<Medcart> Medcarts { get; set; }

    public virtual DbSet<Medempl> Medempls { get; set; }

    public virtual DbSet<Parantschild> Parantschildren { get; set; }

    public virtual DbSet<Parent> Parents { get; set; }

    public virtual DbSet<Parentacc> Parentaccs { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<Voucher> Vouchers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("uuid-ossp");
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
