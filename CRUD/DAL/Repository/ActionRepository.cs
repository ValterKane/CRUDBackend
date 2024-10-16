using CRUD.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Action = CRUD.DAL.Entities.Action;

namespace CRUD.DAL.Repository;

public class ActionRepository : IRepository<Action>
{
    private readonly MyDbContext _context;
    private bool _disposed = false;

    public ActionRepository(MyDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Action> GetAll()
    {
        return _context.Actions;
    }

    public void Add(Action item)
    {
        _context.Actions.Add(item);
        _context.SaveChanges();
    }

    public void Update(Action item)
    {
        _context.Entry(item).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void Delete(Action item)
    {
        var actionToRemove = _context.Actions.Where(x => x.Actuuid == item.Actuuid).FirstOrDefault();

        if (actionToRemove != null)
            _context.Entry(actionToRemove).State = EntityState.Deleted;

        _context.SaveChanges();
    }

    public async Task<IEnumerable<Action>> GetAllAsync()
    {
        return await _context.Set<Action>().ToListAsync();
    }

    public async Task AddAsync(Action item)
    {
        await _context.Set<Action>().AddAsync(item);
        await _context.SaveChangesAsync();
    }

    public virtual void Dispose(bool disposing)
    {
        if (!this._disposed)
            if (disposing)
                _context.Dispose();

        this._disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
