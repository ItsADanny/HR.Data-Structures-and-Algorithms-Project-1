using Microsoft.EntityFrameworkCore;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly AppContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(AppContext appContext)
    {
        _context = appContext;
        _dbSet = _context.Set<T>();
    }
    
    public void Add(T entity)
    {
        if (entity == null) throw new ArgumentNullException();
        _dbSet.Add(entity);
        _context.SaveChangesAsync();
    }

    public void Delete(T entity) {
        _dbSet.Remove(entity);
        _context.SaveChangesAsync();
    }

    public T[] Read() => _dbSet.ToArray();

    public void Update(T entity)
    {
        _dbSet.Update(entity);
        _context.SaveChangesAsync();
    } 
}