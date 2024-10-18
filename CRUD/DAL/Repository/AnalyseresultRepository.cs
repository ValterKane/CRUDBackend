using CRUD.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUD.DAL.Repository;

public sealed class AnalyseresultRepository(DbContext context) : IRepository<Analyseresult>
{
    private bool _disposed = false;

    public IEnumerable<Analyseresult> GetAll()
    {
        return context.Set<Analyseresult>();
    }

    public void Add(Analyseresult item)
    {
        context.Set<Analyseresult>().Add(item);
        context.SaveChanges();
    }

    public async Task AddAsync(Analyseresult item)
    {
        await context.Set<Analyseresult>().AddAsync(item);
    }

    public async Task AddRangeAsync(params Analyseresult[] items)
    {
        if (items.Length == 0) return;
        await context.Set<Analyseresult>().AddRangeAsync(items);
        await context.SaveChangesAsync();
    }

    public void AddRange(params Analyseresult[] items)
    {
        if (items.Length == 0) return;
        context.Set<Analyseresult>().AddRange(items);
        context.SaveChanges();
    }

    public void Update(Analyseresult item)
    {
        context.Entry(item).State = EntityState.Modified;
        context.SaveChanges();
    }

    public void Delete(Analyseresult item)
    {
        var actionToRemove = context.Set<Analyseresult>().FirstOrDefault(x => x.Resid == item.Resid);

        if (actionToRemove != null)
            context.Set<Analyseresult>().Remove(actionToRemove);

        context.SaveChanges();
    }

    public async Task<IEnumerable<Analyseresult>> GetAllAsync()
    {
        await context.Set<Analyseresult>().LoadAsync();
        return context.Set<Analyseresult>();
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
