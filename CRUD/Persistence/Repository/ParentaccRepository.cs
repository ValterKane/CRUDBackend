using CRUD.DAL.Context;
using CRUD.DAL.Entities;
using CRUD.DAL.Repository;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Persistence.Repository;

public class ParentaccRepository(MyDbContext context) : IRepository<Parentacc>
{
    private bool _disposed = false;

    public IEnumerable<Parentacc> GetAll()
    {
        return context.Set<Parentacc>();
    }

    public void Add(Parentacc item)
    {
        if (context.Set<Parentacc>().Contains(item))
            throw new ArgumentException($"{nameof(item)} already contains!");

        context.Set<Parentacc>().Add(item);
        context.SaveChanges();
    }

    public async Task AddAsync(Parentacc item)
    {
        if (context.Set<Parentacc>().Contains(item))
            throw new ArgumentException($"{nameof(item)} already contains!");

        await context.Set<Parentacc>().AddAsync(item);
        await context.SaveChangesAsync();
    }

    public async Task AddRangeAsync(params Parentacc[] items)
    {
        if (items.Length == 0) return;

        foreach (var item in items)
        {
            if (context.Set<Parentacc>().Contains(item))
                throw new ArgumentException($"{nameof(item)} already contains!");
        }

        await context.Set<Parentacc>().AddRangeAsync(items);
        await context.SaveChangesAsync();
    }

    public void AddRange(params Parentacc[] items)
    {
        if (items.Length == 0) return;

        foreach (var item in items)
        {
            if (context.Set<Parentacc>().Contains(item))
                throw new ArgumentException($"{nameof(item)} already contains!");
        }

        context.Set<Parentacc>().AddRange(items);
        context.SaveChanges();
    }

    public void Update(Parentacc item)
    {
        context.Entry(item).State = EntityState.Modified;
        context.SaveChanges();
    }

    public void Delete(Parentacc item)
    {
        if (!context.Set<Parentacc>().Contains(item)) return;
        context.Set<Parentacc>().Remove(item);
        context.SaveChanges();
    }

    public async Task<IEnumerable<Parentacc>> GetAllAsync()
    {
        await context.Set<Parentacc>().LoadAsync();
        return context.Set<Parentacc>();
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
