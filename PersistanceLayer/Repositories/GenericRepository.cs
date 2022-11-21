using System.Linq.Expressions;
using MovieAPI.Interfaces;

namespace MovieAPI.Persistance;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly MovieDatabaseContext _context;
    public GenericRepository(MovieDatabaseContext context)
    {
        _context = context;
    }

    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public void AddRange(IEnumerable<T> entities)
    {
        _context.Set<T>().AddRange(entities);
    }

    public void Update(T entity) 
    {
        _context.Set<T>().Update(entity);
    }

    public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
    {
        return _context.Set<T>().Where(expression);
    }

    public IEnumerable<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }

    public T GetById(long id)
    {
        return id != 0 ? _context.Set<T>().Find(id) : null;
    }

    public void Remove(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        _context.Set<T>().RemoveRange(entities);
    }
}
