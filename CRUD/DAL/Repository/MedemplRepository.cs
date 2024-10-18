using CRUD.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Action = System.Action;

namespace CRUD.DAL.Repository;

public class MedemplRepository(DbContext context) : IRepository<Medempl>
{
    private bool _disposed = false;

    public IEnumerable<Medempl> GetAll()
    {
        return context.Set<Medempl>();

    }
    public void Add(Medempl item)
    {
        context.Set<Medempl>().Add(item);
        context.SaveChanges();
    }

    public void AddRange(params Medempl[] items)
    {
        if (items.Length != 0)
        {
            context.Set<Medempl>().AddRange(items);
            context.SaveChanges();
        }
    }

    public void Update(Medempl item)
    {
        context.Entry(item!).State = EntityState.Modified;
        context.SaveChanges();
    }

    public void Delete(Medempl item)
    {
        var actionToRemove = context.Set<Medempl>().FirstOrDefault(x => x.Empluuid == item.Empluuid);

        if (actionToRemove != null)
            context.Set<Medempl>().Remove(actionToRemove);

        context.SaveChanges();
    }

    public async Task<IEnumerable<Medempl>> GetAllAsync()
    {
        await context.Set<Medempl>().LoadAsync();
        return context.Set<Medempl>();
    }

    public async Task AddAsync(Medempl item)
    {
        await context.Set<Medempl>().AddAsync(item);
        await context.SaveChangesAsync();
    }

    public async Task AddRangeAsync(params Medempl[] items)
    {
        if (items.Length != 0)
        {
            await context.Set<Medempl>().AddRangeAsync(items);
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
