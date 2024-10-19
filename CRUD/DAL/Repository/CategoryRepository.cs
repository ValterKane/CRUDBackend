using CRUD.DAL.Context;
using CRUD.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUD.DAL.Repository;

public class CategoryRepository(MyDbContext context) : IRepository<Category>
{
    private bool _disposed = false;

    public IEnumerable<Category> GetAll()
    {
        return context.Set<Category>();
    }

    public void Add(Category item)
    {
        if (context.Set<Category>().Contains(item))
            throw new ArgumentException($"{nameof(item)} already contains!");

        context.Set<Category>().Add(item);
        context.SaveChanges();
    }

    public async Task AddAsync(Category item)
    {
        if (context.Set<Category>().Contains(item))
            throw new ArgumentException($"{nameof(item)} already contains!");

        await context.Set<Category>().AddAsync(item);
        await context.SaveChangesAsync();
    }

    public async Task AddRangeAsync(params Category[] items)
    {
        if (items.Length == 0) return;

        foreach (var item in items)
        {
            if (context.Set<Category>().Contains(item))
                throw new ArgumentException($"{nameof(item)} already contains!");
        }

        await context.Set<Category>().AddRangeAsync(items);
        await context.SaveChangesAsync();
    }

    public void AddRange(params Category[] items)
    {
        if (items.Length == 0) return;

        foreach (var item in items)
        {
            if (context.Set<Category>().Contains(item))
                throw new ArgumentException($"{nameof(item)} already contains!");
        }

        context.Set<Category>().AddRange(items);
        context.SaveChanges();
    }

    public void Update(Category item)
    {
        context.Entry(item).State = EntityState.Modified;
        context.SaveChanges();
    }

    public void Delete(Category item)
    {
        if (!context.Set<Category>().Contains(item)) return;
        context.Set<Category>().Remove(item);
        context.SaveChanges();
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        await context.Set<Category>().LoadAsync();
        return context.Set<Category>();
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
