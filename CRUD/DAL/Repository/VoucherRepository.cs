using CRUD.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Action = System.Action;

namespace CRUD.DAL.Repository;

public class VoucherRepository(DbContext context) : IRepository<Voucher>
{
    private bool _disposed = false;

    public IEnumerable<Voucher> GetAll()
    {
        return context.Set<Voucher>();
    }

    public void Add(Voucher item)
    {
        context.Set<Voucher>().Add(item);
        context.SaveChanges();
    }

    public void AddRange(params Voucher[] items)
    {
        if (items.Length != 0)
        {
            context.Set<Voucher>().AddRange(items);
            context.SaveChanges();
        }
    }

    public void Update(Voucher item)
    {
        context.Entry(item).State = EntityState.Modified;
        context.SaveChanges();
    }

    public void Delete(Voucher item)
    {
        var actionToRemove = context.Set<Voucher>().FirstOrDefault(x => x.Void == item.Void);

        if (actionToRemove != null)
            context.Set<Voucher>().Remove(actionToRemove);

        context.SaveChanges();
    }

    public async Task<IEnumerable<Voucher>> GetAllAsync()
    {
        await context.Set<Voucher>().LoadAsync();
        return context.Set<Voucher>();
    }

    public async Task AddAsync(Voucher item)
    {
        await context.Set<Voucher>().AddAsync(item);
        await context.SaveChangesAsync();
    }

    public async Task AddRangeAsync(params Voucher[] items)
    {
        if (items.Length != 0)
        {
            await context.Set<Voucher>().AddRangeAsync(items);
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
