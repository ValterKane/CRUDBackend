using CRUD.DAL.Context;
using CRUD.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUD.DAL.Repository;

public class ScheduleRepository(MyDbContext context) : IRepository<Schedule>
{
    private bool _disposed = false;

    public IEnumerable<Schedule> GetAll()
    {
        return context.Set<Schedule>();
    }

    public void Add(Schedule item)
    {
        if (context.Set<Schedule>().Contains(item))
            throw new ArgumentException($"{nameof(item)} already contains!");

        context.Set<Schedule>().Add(item);
        context.SaveChanges();
    }

    public async Task AddAsync(Schedule item)
    {
        if (context.Set<Schedule>().Contains(item))
            throw new ArgumentException($"{nameof(item)} already contains!");

        await context.Set<Schedule>().AddAsync(item);
        await context.SaveChangesAsync();
    }

    public async Task AddRangeAsync(params Schedule[] items)
    {
        if (items.Length == 0) return;

        foreach (var item in items)
        {
            if (context.Set<Schedule>().Contains(item))
                throw new ArgumentException($"{nameof(item)} already contains!");
        }

        await context.Set<Schedule>().AddRangeAsync(items);
        await context.SaveChangesAsync();
    }

    public void AddRange(params Schedule[] items)
    {
        if (items.Length == 0) return;

        foreach (var item in items)
        {
            if (context.Set<Schedule>().Contains(item))
                throw new ArgumentException($"{nameof(item)} already contains!");
        }

        context.Set<Schedule>().AddRange(items);
        context.SaveChanges();
    }

    public void Update(Schedule item)
    {
        context.Entry(item!).State = EntityState.Modified;
        context.SaveChanges();
    }

    public void Delete(Schedule item)
    {
        if (!context.Set<Schedule>().Contains(item)) return;
        context.Set<Schedule>().Remove(item);
        context.SaveChanges();
    }

    public async Task<IEnumerable<Schedule>> GetAllAsync()
    {
        await context.Set<Schedule>().LoadAsync();
        return context.Set<Schedule>();
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
