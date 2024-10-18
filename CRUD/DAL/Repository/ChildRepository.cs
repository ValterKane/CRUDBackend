using CRUD.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUD.DAL.Repository;

public class ChildRepository(DbContext context) : IRepository<Child>
{
    private bool _disposed = false;

    public IEnumerable<Child> GetAll()
    {
        return context.Set<Child>();
    }

    public void Add(Child item)
    {
        context.Set<Child>().Add(item);
        context.SaveChanges();
    }

    public async Task AddAsync(Child item)
    {
        await context.Set<Child>().AddAsync(item);
    }

    public async Task AddRangeAsync(params Child[] items)
    {
        if (items.Length == 0) return;
        await context.Set<Child>().AddRangeAsync(items);
        await context.SaveChangesAsync();
    }

    public void AddRange(params Child[] items)
    {
        if (items.Length == 0) return;
        context.Set<Child>().AddRange(items);
        context.SaveChanges();
    }

    public void Update(Child item)
    {
        context.Entry(item).State = EntityState.Modified;
        context.SaveChanges();
    }

    public void Delete(Child item)
    {
        var actionToRemove = context.Set<Child>().FirstOrDefault(x => x.Chuuid == item.Chuuid);

        if (actionToRemove != null)
            context.Set<Child>().Remove(actionToRemove);

        context.SaveChanges();
    }

    public async Task<IEnumerable<Child>> GetAllAsync()
    {
        await context.Set<Child>().LoadAsync();
        return context.Set<Child>();
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
