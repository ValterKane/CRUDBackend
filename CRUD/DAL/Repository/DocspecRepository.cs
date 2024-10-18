using CRUD.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Action = System.Action;

namespace CRUD.DAL.Repository;

public class DocspecRepository(DbContext context) : IRepository<Docspec>
{
    private bool _disposed = false;

    public IEnumerable<Docspec> GetAll()
    {
        return context.Set<Docspec>();

    }
    public void Add(Docspec item)
    {
        context.Set<Docspec>().Add(item);
        context.SaveChanges();
    }

    public void AddRange(params Docspec[] items)
    {
        if (items.Length != 0)
        {
            context.Set<Docspec>().AddRange(items);
            context.SaveChanges();
        }
    }

    public void Update(Docspec item)
    {
        context.Entry(item!).State = EntityState.Modified;
        context.SaveChanges();
    }

    public void Delete(Docspec item)
    {
        var actionToRemove = context.Set<Docspec>().FirstOrDefault(x => x.Specid == item.Specid);

        if (actionToRemove != null)
            context.Set<Docspec>().Remove(actionToRemove);

        context.SaveChanges();
    }

    public async Task<IEnumerable<Docspec>> GetAllAsync()
    {
        await context.Set<Docspec>().LoadAsync();
        return context.Set<Docspec>();
    }

    public async Task AddAsync(Docspec item)
    {
        await context.Set<Docspec>().AddAsync(item);
        await context.SaveChangesAsync();
    }

    public async Task AddRangeAsync(params Docspec[] items)
    {
        if (items.Length != 0)
        {
            await context.Set<Docspec>().AddRangeAsync(items);
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
