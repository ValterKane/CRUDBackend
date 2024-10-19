using CRUD.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Action = CRUD.DAL.Entities.Action;

namespace CRUD.DAL.Repository;

public sealed class ActionRepository(MyDbContext context) : IRepository<Action>
{
    private bool _disposed = false;

    public IEnumerable<Action> GetAll()
    {
        return context.Set<Action>();
    }

    public void Add(Action item)
    {
        if (context.Set<Action>().Contains(item)) throw new ArgumentException($"{nameof(item)} already contains!");
        context.Set<Action>().Add(item);
        context.SaveChanges();
    }

    public async Task AddAsync(Action item)
    {
        if (context.Set<Action>().Contains(item)) throw new ArgumentException($"{nameof(item)} already contains!");
        await context.Set<Action>().AddAsync(item);
        await context.SaveChangesAsync();
    }

    public void AddRange(params Action[] items)
    {
        if (items.Length != 0)
        {
            foreach (var item in items)
            {
                if (context.Set<Action>().Contains(item))
                    throw new ArgumentException($"{nameof(item)} already contains!");
            }

            context.Set<Action>().AddRange(items);
            context.SaveChanges();
        }
    }

    public async Task AddRangeAsync(params Action[] items)
    {
        if (items.Length != 0)
        {
            foreach (var item in items)
            {
                if (context.Set<Action>().Contains(item))
                    throw new ArgumentException($"{nameof(item)} already contains!");
            }

            await context.Set<Action>().AddRangeAsync(items);
            await context.SaveChangesAsync();
        }
    }

    public void Update(Action item)
    {
        context.Entry(item).State = EntityState.Modified;
        context.SaveChanges();
    }

    public void Delete(Action item)
    {
        if (!context.Set<Action>().Contains(item)) return;
        context.Set<Action>().Remove(item);
        context.SaveChanges();
    }

    public async Task<IEnumerable<Action>> GetAllAsync()
    {
        await context.Set<Action>().LoadAsync();
        return context.Set<Action>();
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
