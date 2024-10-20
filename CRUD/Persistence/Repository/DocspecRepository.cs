using CRUD.DAL.Context;
using CRUD.DAL.Entities;
using CRUD.DAL.Repository;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Persistence.Repository;

public class DocspecRepository(MyDbContext context) : IRepository<Docspec>
{
    private bool _disposed = false;

    public IEnumerable<Docspec> GetAll()
    {
        return context.Set<Docspec>();
    }

    public void Add(Docspec item)
    {
        if (context.Set<Docspec>().Contains(item))
            throw new ArgumentException($"{nameof(item)} already contains!");

        context.Set<Docspec>().Add(item);
        context.SaveChanges();
    }

    public void AddRange(params Docspec[] items)
    {
        if (items.Length == 0) return;

        foreach (var item in items)
        {
            if (context.Set<Docspec>().Contains(item))
                throw new ArgumentException($"{nameof(item)} already contains!");
        }

        context.Set<Docspec>().AddRange(items);
        context.SaveChanges();
    }

    public async Task AddAsync(Docspec item)
    {
        if (context.Set<Docspec>().Contains(item))
            throw new ArgumentException($"{nameof(item)} already contains!");

        await context.Set<Docspec>().AddAsync(item);
        await context.SaveChangesAsync();
    }

    public async Task AddRangeAsync(params Docspec[] items)
    {
        if (items.Length == 0) return;

        foreach (var item in items)
        {
            if (context.Set<Docspec>().Contains(item))
                throw new ArgumentException($"{nameof(item)} already contains!");
        }

        await context.Set<Docspec>().AddRangeAsync(items);
        await context.SaveChangesAsync();
    }

    public void Update(Docspec item)
    {
        context.Entry(item!).State = EntityState.Modified;
        context.SaveChanges();
    }

    public void Delete(Docspec item)
    {
        if (!context.Set<Docspec>().Contains(item)) return;
        context.Set<Docspec>().Remove(item);
        context.SaveChanges();
    }

    public async Task<IEnumerable<Docspec>> GetAllAsync()
    {
        await context.Set<Docspec>().LoadAsync();
        return context.Set<Docspec>();
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
