using CRUD.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Action = CRUD.DAL.Entities.Action;

namespace CRUD.DAL.Repository;

public sealed class ActiontypeRepository(DbContext context) : IRepository<Actiontype>
{
    private bool _disposed = false;

    public IEnumerable<Actiontype> GetAll()
    {
        return context.Set<Actiontype>();
    }

    public void Add(Actiontype item)
    {
        context.Set<Actiontype>().Add(item);
        context.SaveChanges();
    }

    public void AddRange(params Actiontype[] items)
    {
        if (items.Length == 0) return;
        context.Set<Actiontype>().AddRange(items);
        context.SaveChanges();
    }

    public void Update(Actiontype item)
    {
        context.Entry(item).State = EntityState.Modified;
        context.SaveChanges();
    }

    public void Delete(Actiontype item)
    {
        var actionToRemove = context.Set<Actiontype>().FirstOrDefault(x => x.TypeId == item.TypeId);

        if (actionToRemove != null)
            context.Set<Actiontype>().Remove(actionToRemove);

        context.SaveChanges();
    }

    public async Task<IEnumerable<Actiontype>> GetAllAsync()
    {
        await context.Set<Actiontype>().LoadAsync();
        return context.Set<Actiontype>();
    }

    public async Task AddAsync(Actiontype item)
    {
        await context.Set<Actiontype>().AddAsync(item);
    }

    public async Task AddRangeAsync(params Actiontype[] items)
    {
        if (items.Length == 0) return;
        await context.Set<Actiontype>().AddRangeAsync(items);
        await context.SaveChangesAsync();
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
