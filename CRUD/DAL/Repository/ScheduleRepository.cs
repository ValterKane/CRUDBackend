using CRUD.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUD.DAL.Repository;

public class ScheduleRepository(DbContext context) : IRepository<Schedule>
{
    private bool _disposed = false;

    public IEnumerable<Schedule> GetAll()
    {
        return context.Set<Schedule>();

    }
    public void Add(Schedule item)
    {
        context.Set<Schedule>().Add(item);
        context.SaveChanges();
    }

    public void AddRange(params Schedule[] items)
    {
        if (items.Length != 0)
        {
            context.Set<Schedule>().AddRange(items);
            context.SaveChanges();
        }
    }

    public void Update(Schedule item)
    {
        context.Entry(item!).State = EntityState.Modified;
        context.SaveChanges();
    }

    public void Delete(Schedule item)
    {
        var actionToRemove = context.Set<Schedule>().FirstOrDefault(x => x.Timemark == item.Timemark && x.Chuuid == item.Chuuid);

        if (actionToRemove != null)
            context.Set<Schedule>().Remove(actionToRemove);

        context.SaveChanges();

    }

    public async Task<IEnumerable<Schedule>> GetAllAsync()
    {
        await context.Set<Schedule>().LoadAsync();
        return context.Set<Schedule>();
    }

    public async Task AddAsync(Schedule item)
    {
        await context.Set<Schedule>().AddAsync(item);
        await context.SaveChangesAsync();
    }

    public async Task AddRangeAsync(params Schedule[] items)
    {
        if (items.Length != 0)
        {
            await context.Set<Schedule>().AddRangeAsync(items);
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
