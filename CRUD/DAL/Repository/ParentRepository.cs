using CRUD.DAL.Context;
using CRUD.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Action = System.Action;

namespace CRUD.DAL.Repository;

public class ParentRepository(MyDbContext context) : IRepository<Parent>
{
    private bool _disposed = false;

    public IEnumerable<Parent> GetAll()
    {
        return context.Set<Parent>();
    }

    public void Add(Parent item)
    {
        if (context.Set<Parent>().Contains(item))
            throw new ArgumentException($"{nameof(item)} already contains!");

        context.Set<Parent>().Add(item);
        context.SaveChanges();
    }

    public async Task AddAsync(Parent item)
    {
        if (context.Set<Parent>().Contains(item))
            throw new ArgumentException($"{nameof(item)} already contains!");

        await context.Set<Parent>().AddAsync(item);
        await context.SaveChangesAsync();
    }

    public async Task AddRangeAsync(params Parent[] items)
    {
        if (items.Length == 0) return;

        foreach (var item in items)
        {
            if (context.Set<Parent>().Contains(item))
                throw new ArgumentException($"{nameof(item)} already contains!");
        }

        await context.Set<Parent>().AddRangeAsync(items);
        await context.SaveChangesAsync();
    }

    public void AddRange(params Parent[] items)
    {
        if (items.Length == 0) return;

        foreach (var item in items)
        {
            if (context.Set<Parent>().Contains(item))
                throw new ArgumentException($"{nameof(item)} already contains!");
        }

        context.Set<Parent>().AddRange(items);
        context.SaveChanges();
    }

    public void Update(Parent item)
    {
        context.Entry(item!).State = EntityState.Modified;
        context.SaveChanges();
    }

    public void Delete(Parent item)
    {
        if (!context.Set<Parent>().Contains(item)) return;
        context.Set<Parent>().Remove(item);
        context.SaveChanges();
    }

    public async Task<IEnumerable<Parent>> GetAllAsync()
    {
        await context.Set<Parent>().LoadAsync();
        return context.Set<Parent>();
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
