using CRUD.DAL.Context;
using CRUD.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUD.DAL.Repository;

public class ChildRepository(MyDbContext context) : IRepository<Child>
{
    private bool _disposed = false;

    public IEnumerable<Child> GetAll()
    {
        return context.Set<Child>();
    }

    public void Add(Child item)
    {
        if (context.Set<Child>().Contains(item))
            throw new ArgumentException($"{nameof(item)} already contains!");

        context.Set<Child>().Add(item);
        context.SaveChanges();
    }

    public async Task AddAsync(Child item)
    {
        if (context.Set<Child>().Contains(item))
            throw new ArgumentException($"{nameof(item)} already contains!");

        await context.Set<Child>().AddAsync(item);
        await context.SaveChangesAsync();
    }

    public async Task AddRangeAsync(params Child[] items)
    {
        if (items.Length == 0) return;

        foreach (var item in items)
        {
            if (context.Set<Child>().Contains(item))
                throw new ArgumentException($"{nameof(item)} already contains!");
        }

        await context.Set<Child>().AddRangeAsync(items);
        await context.SaveChangesAsync();
    }

    public void AddRange(params Child[] items)
    {
        if (items.Length == 0) return;

        foreach (var item in items)
        {
            if (context.Set<Child>().Contains(item))
                throw new ArgumentException($"{nameof(item)} already contains!");
        }

        context.Set<Child>().AddRange(items);
        context.SaveChanges();
    }

    public void Update(Child item)
    {
        context.Entry(item).State = EntityState.Modified;
        context.SaveChanges();
    }

    public void Delete(Child item)
    {
        if (!context.Set<Child>().Contains(item)) return;
        context.Set<Child>().Remove(item);
        context.SaveChanges();
    }

    public async Task<IEnumerable<Child>> GetAllAsync()
    {
        await context.Set<Child>().LoadAsync();
        return context.Set<Child>();
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
