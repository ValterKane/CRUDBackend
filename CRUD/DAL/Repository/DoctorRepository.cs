using CRUD.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Action = System.Action;

namespace CRUD.DAL.Repository;

public class DoctorRepository(DbContext context): IRepository<Doctor>
{
    private bool _disposed = false;

    public IEnumerable<Doctor> GetAll()
    {
        return context.Set<Doctor>();

    }
    public void Add(Doctor item)
    {
        context.Set<Doctor>().Add(item);
        context.SaveChanges();
    }

    public void AddRange(params Doctor[] items)
    {
        if (items.Length != 0)
        {
            context.Set<Doctor>().AddRange(items);
            context.SaveChanges();
        }
    }

    public void Update(Doctor item)
    {
        context.Entry(item!).State = EntityState.Modified;
        context.SaveChanges();
    }

    public void Delete(Doctor item)
    {
        var actionToRemove = context.Set<Doctor>().FirstOrDefault(x => x.Docuuid == item.Docuuid);

        if (actionToRemove != null)
            context.Set<Doctor>().Remove(actionToRemove);

        context.SaveChanges();
    }

    public async Task<IEnumerable<Doctor>> GetAllAsync()
    {
        await context.Set<Doctor>().LoadAsync();
        return context.Set<Doctor>();
    }

    public async Task AddAsync(Doctor item)
    {
        await context.Set<Doctor>().AddAsync(item);
        await context.SaveChangesAsync();
    }

    public async Task AddRangeAsync(params Doctor[] items)
    {
        if (items.Length != 0)
        {
            await context.Set<Doctor>().AddRangeAsync(items);
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
