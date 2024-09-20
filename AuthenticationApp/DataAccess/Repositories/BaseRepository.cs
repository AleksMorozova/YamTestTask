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
    private readonly ILogger _logger;
    private readonly DbContext _context;
    protected readonly DbSet<T> _dbSet;

    public BaseRepository(DbContext context, ILogger<BaseRepository<T>> logger)
    {
        _logger = logger;
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<T> GetById(Guid id)
    {
        try { 
            return await _dbSet.FindAsync(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            throw;
        }
    }

    public List<T> GetAll()
    {
        try
        {
            return _dbSet.ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            throw;
        }
    }

    public async Task<T> AddAsync(T entity)
    {
        try
        {
            var e = await _dbSet.AddAsync(entity);
            _context.SaveChanges();
            return e.Entity;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            throw;
        }
    }

    public T Update(T entity)
    {
        try
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
            return entity;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            throw;
        }
    }
}
