using CRUD.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Action = System.Action;

namespace CRUD.DAL.Repository;

public class MedcartRepository(DbContext context): IRepository<Medcart>
{
    private bool _disposed = false;

    public IEnumerable<Medcart> GetAll()
    {
        return context.Set<Medcart>();

    }
    public void Add(Medcart item)
    {
        context.Set<Medcart>().Add(item);
        context.SaveChanges();
    }

    public void AddRange(params Medcart[] items)
    {
        if (items.Length != 0)
        {
            context.Set<Medcart>().AddRange(items);
            context.SaveChanges();
        }
    }

    public void Update(Medcart item)
    {
        context.Entry(item!).State = EntityState.Modified;
        context.SaveChanges();
    }

    public void Delete(Medcart item)
    {
        var actionToRemove = context.Set<Medcart>().FirstOrDefault(x => x.Timemark == item.Timemark && x.Chuu == item.Chuu);

        if (actionToRemove != null)
            context.Set<Medcart>().Remove(actionToRemove);

        context.SaveChanges();

    }

    public async Task<IEnumerable<Medcart>> GetAllAsync()
    {
        await context.Set<Medcart>().LoadAsync();
        return context.Set<Medcart>();
    }

    public async Task AddAsync(Medcart item)
    {
        await context.Set<Medcart>().AddAsync(item);
        await context.SaveChangesAsync();
    }

    public async Task AddRangeAsync(params Medcart[] items)
    {
        if (items.Length != 0)
        {
            await context.Set<Medcart>().AddRangeAsync(items);
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
