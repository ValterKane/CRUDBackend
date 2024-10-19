using CRUD.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Action = System.Action;

namespace CRUD.DAL.Repository;

public class EmplaccRepository(DbContext context) : IRepository<Emplsaccdatum>
{
    private bool _disposed = false;

    public IEnumerable<Emplsaccdatum> GetAll()
    {
        return context.Set<Emplsaccdatum>();
    }

    public void Add(Emplsaccdatum item)
    {
        if (context.Set<Emplsaccdatum>().Contains(item))
            throw new ArgumentException($"{nameof(item)} already contains!");

        context.Set<Emplsaccdatum>().Add(item);
        context.SaveChanges();
    }

    public async Task AddAsync(Emplsaccdatum item)
    {
        if (context.Set<Emplsaccdatum>().Contains(item))
            throw new ArgumentException($"{nameof(item)} already contains!");

        await context.Set<Emplsaccdatum>().AddAsync(item);
        await context.SaveChangesAsync();
    }

    public async Task AddRangeAsync(params Emplsaccdatum[] items)
    {
        if (items.Length == 0) return;

        foreach (var item in items)
        {
            if (context.Set<Emplsaccdatum>().Contains(item))
                throw new ArgumentException($"{nameof(item)} already contains!");
        }

        await context.Set<Emplsaccdatum>().AddRangeAsync(items);
        await context.SaveChangesAsync();
    }

    public void AddRange(params Emplsaccdatum[] items)
    {
        foreach (var item in items)
        {
            if (context.Set<Emplsaccdatum>().Contains(item))
                throw new ArgumentException($"{nameof(item)} already contains!");
        }

        context.Set<Emplsaccdatum>().AddRange(items);
        context.SaveChanges();
    }

    public void Update(Emplsaccdatum item)
    {
        context.Entry(item!).State = EntityState.Modified;
        context.SaveChanges();
    }

    public void Delete(Emplsaccdatum item)
    {
        if (!context.Set<Emplsaccdatum>().Contains(item)) return;
        context.Set<Emplsaccdatum>().Remove(item);
        context.SaveChanges();
    }

    public async Task<IEnumerable<Emplsaccdatum>> GetAllAsync()
    {
        await context.Set<Emplsaccdatum>().LoadAsync();
        return context.Set<Emplsaccdatum>();
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
