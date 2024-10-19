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
        if (context.Set<Voucher>().Contains(item))
            throw new ArgumentException($"{nameof(item)} already contains!");

        context.Set<Voucher>().Add(item);
        context.SaveChanges();
    }

    public async Task AddAsync(Voucher item)
    {
        if (context.Set<Voucher>().Contains(item))
            throw new ArgumentException($"{nameof(item)} already contains!");

        await context.Set<Voucher>().AddAsync(item);
        await context.SaveChangesAsync();
    }

    public async Task AddRangeAsync(params Voucher[] items)
    {
        if (items.Length == 0) return;

        foreach (var item in items)
        {
            if (context.Set<Voucher>().Contains(item))
                throw new ArgumentException($"{nameof(item)} already contains!");
        }

        await context.Set<Voucher>().AddRangeAsync(items);
        await context.SaveChangesAsync();
    }

    public void AddRange(params Voucher[] items)
    {
        if (items.Length == 0) return;

        foreach (var item in items)
        {
            if (context.Set<Voucher>().Contains(item))
                throw new ArgumentException($"{nameof(item)} already contains!");
        }

        context.Set<Voucher>().AddRange(items);
        context.SaveChanges();
    }

    public void Update(Voucher item)
    {
        context.Entry(item).State = EntityState.Modified;
        context.SaveChanges();
    }

    public void Delete(Voucher item)
    {
        if (!context.Set<Voucher>().Contains(item)) return;
        context.Set<Voucher>().Remove(item);
        context.SaveChanges();
    }

    public async Task<IEnumerable<Voucher>> GetAllAsync()
    {
        await context.Set<Voucher>().LoadAsync();
        return context.Set<Voucher>();
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
