using CRUD.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Action = System.Action;

namespace CRUD.DAL.Repository;

public class ParentchildRepository(DbContext context) : IRepository<Parantschild>
{
    private bool _disposed = false;

    public IEnumerable<Parantschild> GetAll()
    {
        return context.Set<Parantschild>();
    }

    public void Add(Parantschild item)
    {
        if (context.Set<Parantschild>().Contains(item))
            throw new ArgumentException($"{nameof(item)} already contains!");

        context.Set<Parantschild>().Add(item);
        context.SaveChanges();
    }

    public async Task AddAsync(Parantschild item)
    {
        if (context.Set<Parantschild>().Contains(item))
            throw new ArgumentException($"{nameof(item)} already contains!");

        await context.Set<Parantschild>().AddAsync(item);
        await context.SaveChangesAsync();
    }

    public async Task AddRangeAsync(params Parantschild[] items)
    {
        if (items.Length == 0) return;

        foreach (var item in items)
        {
            if (context.Set<Parantschild>().Contains(item))
                throw new ArgumentException($"{nameof(item)} already contains!");
        }

        await context.Set<Parantschild>().AddRangeAsync(items);
        await context.SaveChangesAsync();
    }

    public void AddRange(params Parantschild[] items)
    {
        if (items.Length == 0) return;

        foreach (var item in items)
        {
            if (context.Set<Parantschild>().Contains(item))
                throw new ArgumentException($"{nameof(item)} already contains!");
        }

        context.Set<Parantschild>().AddRange(items);
        context.SaveChanges();
    }

    public void Update(Parantschild item)
    {
        context.Entry(item!).State = EntityState.Modified;
        context.SaveChanges();
    }

    public void Delete(Parantschild item)
    {
        if (!context.Set<Parantschild>().Contains(item)) return;
        context.Set<Parantschild>().Remove(item);
        context.SaveChanges();
    }

    public async Task<IEnumerable<Parantschild>> GetAllAsync()
    {
        await context.Set<Parantschild>().LoadAsync();
        return context.Set<Parantschild>();
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
