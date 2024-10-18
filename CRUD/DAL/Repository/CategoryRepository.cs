using CRUD.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUD.DAL.Repository;
    
public class CategoryRepository(DbContext context) : IRepository<Category>
{
    private bool _disposed = false;

    public IEnumerable<Category> GetAll()
    {
        return context.Set<Category>();
    }

    public void Add(Category item)
    {
        context.Set<Category>().Add(item);
        context.SaveChanges();
    }

    public async Task AddAsync(Category item)
    {
        await context.Set<Category>().AddAsync(item);
    }

    public async Task AddRangeAsync(params Category[] items)
    {
        if (items.Length == 0) return;
        await context.Set<Category>().AddRangeAsync(items);
        await context.SaveChangesAsync();
    }

    public void AddRange(params Category[] items)
    {
        if (items.Length == 0) return;
        context.Set<Category>().AddRange(items);
        context.SaveChanges();
    }

    public void Update(Category item)
    {
        context.Entry(item).State = EntityState.Modified;
        context.SaveChanges();
    }

    public void Delete(Category item)
    {
        var actionToRemove = context.Set<Category>().FirstOrDefault(x => x.Catid == item.Catid);

        if (actionToRemove != null)
            context.Set<Category>().Remove(actionToRemove);

        context.SaveChanges();

    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        await context.Set<Category>().LoadAsync();
        return context.Set<Category>();
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
