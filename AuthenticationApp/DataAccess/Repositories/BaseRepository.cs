using Microsoft.EntityFrameworkCore;

namespace AuthenticationApp.DataAccess.Repositories;

public interface IRepository<T>
{
    Task<T> GetById(Guid id);
    List<T> GetAll();
    Task<T> AddAsync(T entity);
    T Update(T entity);
}

public class BaseRepository<T> : IRepository<T> where T : class
{
    private readonly DbContext _context;
    protected readonly DbSet<T> _dbSet;
    public BaseRepository(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<T> GetById(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public List<T> GetAll()
    {
        return _dbSet.ToList();
    }

    public async Task<T> AddAsync(T entity)
    {
        var e = await _dbSet.AddAsync(entity);
        _context.SaveChanges();
        return e.Entity;
    }

    public T Update(T entity)
    {
        _dbSet.Update(entity);
        _context.SaveChanges();
        return entity;
    }
}
