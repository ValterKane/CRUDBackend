using CRUD.DAL.Context;
using CRUD.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Action = System.Action;

namespace CRUD.DAL.Repository;

public class DoctorRepository(MyDbContext context) : IRepository<Doctor>
{
    private bool _disposed = false;

    public IEnumerable<Doctor> GetAll()
    {
        return context.Set<Doctor>();
    }

    public void Add(Doctor item)
    {
        if (context.Set<Doctor>().Contains(item))
            throw new ArgumentException($"{nameof(item)} already contains!");

        context.Set<Doctor>().Add(item);
        context.SaveChanges();
    }

    public async Task AddAsync(Doctor item)
    {
        if (context.Set<Doctor>().Contains(item))
            throw new ArgumentException($"{nameof(item)} already contains!");

        await context.Set<Doctor>().AddAsync(item);
        await context.SaveChangesAsync();
    }

    public async Task AddRangeAsync(params Doctor[] items)
    {
        if (items.Length == 0) return;

        foreach (var item in items)
        {
            if (context.Set<Doctor>().Contains(item))
                throw new ArgumentException($"{nameof(item)} already contains!");
        }

        await context.Set<Doctor>().AddRangeAsync(items);
        await context.SaveChangesAsync();
    }

    public void AddRange(params Doctor[] items)
    {
        if (items.Length == 0) return;

        foreach (var item in items)
        {
            if (context.Set<Doctor>().Contains(item))
                throw new ArgumentException($"{nameof(item)} already contains!");
        }

        context.Set<Doctor>().AddRange(items);
        context.SaveChanges();
    }

    public void Update(Doctor item)
    {
        context.Entry(item!).State = EntityState.Modified;
        context.SaveChanges();
    }

    public void Delete(Doctor item)
    {
        if (!context.Set<Doctor>().Contains(item)) return;
        context.Set<Doctor>().Remove(item);
        context.SaveChanges();
    }

    public async Task<IEnumerable<Doctor>> GetAllAsync()
    {
        await context.Set<Doctor>().LoadAsync();
        return context.Set<Doctor>();
    }

    private void Dispose(bool disposing)
    {
        if (!this._disposed)
            if (disposing)
                context.Dispose();

        this._disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
