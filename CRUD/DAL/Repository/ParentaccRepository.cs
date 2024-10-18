using CRUD.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUD.DAL.Repository;

public class ParentaccRepository(DbContext context) : IRepository<Parentacc>
{
    private bool _disposed = false;

    public IEnumerable<Parentacc> GetAll()
    {
        return context.Set<Parentacc>();
    }

    public void Add(Parentacc item)
    {
        context.Set<Parentacc>().Add(item);
        context.SaveChanges();
    }

    public void AddRange(params Parentacc[] items)
    {
        if (items.Length != 0)
        {
            context.Set<Parentacc>().AddRange(items);
            context.SaveChanges();
        }
    }

    public void Update(Parentacc item)
    {
        context.Entry(item).State = EntityState.Modified;
        context.SaveChanges();
    }

    public void Delete(Parentacc item)
    {
        var actionToRemove = context.Set<Parentacc>().FirstOrDefault(x => x.Paruuid == item.Paruuid);

        if (actionToRemove != null)
            context.Set<Parentacc>().Remove(actionToRemove);

        context.SaveChanges();
    }

    public async Task<IEnumerable<Parentacc>> GetAllAsync()
    {
        await context.Set<Parentacc>().LoadAsync();
        return context.Set<Parentacc>();
    }

    public async Task AddAsync(Parentacc item)
    {
        await context.Set<Parentacc>().AddAsync(item);
        await context.SaveChangesAsync();
    }

    public async Task AddRangeAsync(params Parentacc[] items)
    {
        if (items.Length != 0)
        {
            await context.Set<Parentacc>().AddRangeAsync(items);
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
