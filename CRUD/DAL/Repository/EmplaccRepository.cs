using CRUD.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Action = System.Action;

namespace CRUD.DAL.Repository;

public class EmplaccRepository(DbContext context): IRepository<Emplsaccdatum>
{
    private bool _disposed = false;

    public IEnumerable<Emplsaccdatum> GetAll()
    {
        return context.Set<Emplsaccdatum>();

    }
    public void Add(Emplsaccdatum item)
    {
        context.Set<Emplsaccdatum>().Add(item);
        context.SaveChanges();
    }

    public void AddRange(params Emplsaccdatum[] items)
    {
        if (items.Length != 0)
        {
            context.Set<Emplsaccdatum>().AddRange(items);
            context.SaveChanges();
        }
    }

    public void Update(Emplsaccdatum item)
    {
        context.Entry(item!).State = EntityState.Modified;
        context.SaveChanges();
    }

    public void Delete(Emplsaccdatum item)
    {
        var actionToRemove = context.Set<Emplsaccdatum>().FirstOrDefault(x => x.Empluuid == item.Empluuid);

        if (actionToRemove != null)
            context.Set<Emplsaccdatum>().Remove(actionToRemove);

        context.SaveChanges();
    }

    public async Task<IEnumerable<Emplsaccdatum>> GetAllAsync()
    {
        await context.Set<Emplsaccdatum>().LoadAsync();
        return context.Set<Emplsaccdatum>();
    }

    public async Task AddAsync(Emplsaccdatum item)
    {
        await context.Set<Emplsaccdatum>().AddAsync(item);
        await context.SaveChangesAsync();
    }

    public async Task AddRangeAsync(params Emplsaccdatum[] items)
    {
        if (items.Length != 0)
        {
            await context.Set<Emplsaccdatum>().AddRangeAsync(items);
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
