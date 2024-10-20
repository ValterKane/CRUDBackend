using CRUD.DAL.Context;
using CRUD.DAL.Entities;
using CRUD.DAL.Repository;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Persistence.Repository;

public class MedcartRepository(MyDbContext context) : IRepository<Medcart>
{
    private bool _disposed = false;

    public IEnumerable<Medcart> GetAll()
    {
        return context.Set<Medcart>();
    }

    public void Add(Medcart item)
    {
        if (context.Set<Medcart>().Contains(item))
            throw new ArgumentException($"{nameof(item)} already contains!");

        context.Set<Medcart>().Add(item);
        context.SaveChanges();
    }

    public async Task AddAsync(Medcart item)
    {
        if (context.Set<Medcart>().Contains(item))
            throw new ArgumentException($"{nameof(item)} already contains!");

        await context.Set<Medcart>().AddAsync(item);
        await context.SaveChangesAsync();
    }

    public async Task AddRangeAsync(params Medcart[] items)
    {
        if (items.Length == 0) return;

        foreach (var item in items)
        {
            if (context.Set<Medcart>().Contains(item))
                throw new ArgumentException($"{nameof(item)} already contains!");
        }

        await context.Set<Medcart>().AddRangeAsync(items);
        await context.SaveChangesAsync();
    }

    public void AddRange(params Medcart[] items)
    {
        if (items.Length == 0) return;

        foreach (var item in items)
        {
            if (context.Set<Medcart>().Contains(item))
                throw new ArgumentException($"{nameof(item)} already contains!");
        }

        context.Set<Medcart>().AddRange(items);
        context.SaveChanges();
    }

    public void Update(Medcart item)
    {
        context.Entry(item!).State = EntityState.Modified;
        context.SaveChanges();
    }

    public void Delete(Medcart item)
    {
        if (!context.Set<Medcart>().Contains(item)) return;
        context.Set<Medcart>().Remove(item);
        context.SaveChanges();
    }

    public async Task<IEnumerable<Medcart>> GetAllAsync()
    {
        await context.Set<Medcart>().LoadAsync();
        return context.Set<Medcart>();
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
