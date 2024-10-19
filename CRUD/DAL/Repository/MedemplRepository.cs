using CRUD.DAL.Context;
using CRUD.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Action = System.Action;

namespace CRUD.DAL.Repository;

public class MedemplRepository(MyDbContext context) : IRepository<Medempl>
{
    private bool _disposed = false;

    public IEnumerable<Medempl> GetAll()
    {
        return context.Set<Medempl>();
    }

    public void Add(Medempl item)
    {
        if (context.Set<Medempl>().Contains(item))
            throw new ArgumentException($"{nameof(item)} already contains!");

        context.Set<Medempl>().Add(item);
        context.SaveChanges();
    }

    public async Task AddAsync(Medempl item)
    {
        if (context.Set<Medempl>().Contains(item))
            throw new ArgumentException($"{nameof(item)} already contains!");

        await context.Set<Medempl>().AddAsync(item);
        await context.SaveChangesAsync();
    }

    public async Task AddRangeAsync(params Medempl[] items)
    {
        if (items.Length == 0) return;

        foreach (var item in items)
        {
            if (context.Set<Medempl>().Contains(item))
                throw new ArgumentException($"{nameof(item)} already contains!");
        }

        await context.Set<Medempl>().AddRangeAsync(items);
        await context.SaveChangesAsync();
    }

    public void AddRange(params Medempl[] items)
    {
        if (items.Length == 0) return;

        foreach (var item in items)
        {
            if (context.Set<Medempl>().Contains(item))
                throw new ArgumentException($"{nameof(item)} already contains!");
        }

        context.Set<Medempl>().AddRange(items);
        context.SaveChanges();
    }

    public void Update(Medempl item)
    {
        context.Entry(item!).State = EntityState.Modified;
        context.SaveChanges();
    }

    public void Delete(Medempl item)
    {
        if (!context.Set<Medempl>().Contains(item)) return;
        context.Set<Medempl>().Remove(item);
        context.SaveChanges();
    }

    public async Task<IEnumerable<Medempl>> GetAllAsync()
    {
        await context.Set<Medempl>().LoadAsync();
        return context.Set<Medempl>();
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
