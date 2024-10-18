using CRUD.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Action = System.Action;

namespace CRUD.DAL.Repository;

public class ParentRepository(DbContext context) : IRepository<Parent>
{
    private bool _disposed = false;

    public IEnumerable<Parent> GetAll()
    {
        return context.Set<Parent>();
    }

    public void Add(Parent item)
    {
        context.Set<Parent>().Add(item);
        context.SaveChanges();
    }

    public void AddRange(params Parent[] items)
    {
        if (items.Length != 0)
        {
            context.Set<Parent>().AddRange(items);
            context.SaveChanges();
        }
    }

    public void Update(Parent item)
    {
        context.Entry(item!).State = EntityState.Modified;
        context.SaveChanges();
    }

    public void Delete(Parent item)
    {
        var actionToRemove = context.Set<Parent>().FirstOrDefault(x => x.Paruuid == item.Paruuid);

        if (actionToRemove != null)
            context.Set<Parent>().Remove(actionToRemove);

        context.SaveChanges();

    }

    public async Task<IEnumerable<Parent>> GetAllAsync()
    {
        await context.Set<Parent>().LoadAsync();
        return context.Set<Parent>();
    }

    public async Task AddAsync(Parent item)
    {
        await context.Set<Parent>().AddAsync(item);
        await context.SaveChangesAsync();
    }

    public async Task AddRangeAsync(params Parent[] items)
    {
        if (items.Length != 0)
        {
            await context.Set<Parent>().AddRangeAsync(items);
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
