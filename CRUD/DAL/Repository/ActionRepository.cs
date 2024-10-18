using CRUD.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Action = CRUD.DAL.Entities.Action;

namespace CRUD.DAL.Repository;

public sealed class ActionRepository(DbContext context) : IRepository<Action>
{
    private bool _disposed = false;

    public IEnumerable<Action> GetAll()
    {
        return context.Set<Action>();

    }
    public void Add(Action item)
    {
        context.Set<Action>().Add(item);
        context.SaveChanges();
    }

    public void AddRange(params Action[] items)
    {
        if (items.Length != 0)
        {
            context.Set<Action>().AddRange(items);
            context.SaveChanges();
        }
    }

    public void Update(Action item)
    {
        context.Entry(item!).State = EntityState.Modified;
        context.SaveChanges();
    }

    public void Delete(Action item)
    {
        var actionToRemove = context.Set<Action>().FirstOrDefault(x => x.Actuuid == item.Actuuid);

        if (actionToRemove != null)
            context.Set<Action>().Remove(actionToRemove);

        context.SaveChanges();
    }

    public async Task<IEnumerable<Action>> GetAllAsync()
    {
        await context.Set<Action>().LoadAsync();
        return context.Set<Action>();
    }

    public async Task AddAsync(Action item)
    {
        await context.Set<Action>().AddAsync(item);
        await context.SaveChangesAsync();
    }

    public async Task AddRangeAsync(params Action[] items)
    {
        if (items.Length != 0)
        {
            await context.Set<Action>().AddRangeAsync(items);
            await context.SaveChangesAsync();
        }
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
