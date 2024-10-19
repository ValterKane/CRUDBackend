using CRUD.DAL.Context;
using CRUD.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUD.DAL.Repository;

public sealed class ActiontypeRepository(MyDbContext context) : IRepository<Actiontype>
{
    private bool _disposed = false;

    public IEnumerable<Actiontype> GetAll()
    {
        return context.Set<Actiontype>();
    }

    public void Add(Actiontype item)
    {
        if (context.Set<Actiontype>().Contains(item)) throw new ArgumentException($"{nameof(item)} already contains!");
        context.Set<Actiontype>().Add(item);
        context.SaveChanges();
    }

    public void AddRange(params Actiontype[] items)
    {
        if (items.Length == 0) return;

        foreach (var item in items)
        {
            if (context.Set<Actiontype>().Contains(item))
                throw new ArgumentException($"{nameof(item)} already contains!");
        }

        context.Set<Actiontype>().AddRange(items);
        context.SaveChanges();
    }

    public async Task AddAsync(Actiontype item)
    {
        if (context.Set<Actiontype>().Contains(item)) throw new ArgumentException($"{nameof(item)} already contains!");
        await context.Set<Actiontype>().AddAsync(item);
        await context.SaveChangesAsync();
    }

    public async Task AddRangeAsync(params Actiontype[] items)
    {
        if (items.Length == 0) return;

        foreach (var item in items)
        {
            if (context.Set<Actiontype>().Contains(item))
                throw new ArgumentException($"{nameof(item)} already contains!");
        }

        await context.Set<Actiontype>().AddRangeAsync(items);
        await context.SaveChangesAsync();
    }

    public void Update(Actiontype item)
    {
        context.Entry(item).State = EntityState.Modified;
        context.SaveChanges();
    }

    public void Delete(Actiontype item)
    {
        if (!context.Set<Actiontype>().Contains(item)) return;
        context.Set<Actiontype>().Remove(item);
        context.SaveChanges();
    }

    public async Task<IEnumerable<Actiontype>> GetAllAsync()
    {
        await context.Set<Actiontype>().LoadAsync();
        return context.Set<Actiontype>();
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
