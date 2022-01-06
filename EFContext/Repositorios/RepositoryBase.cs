using Dominio;

namespace EFContext.Repositorios;

public class RepositoryBase<TKey, TEntity> : IRepositoryBase<TKey, TEntity> where TEntity : Base<TKey>
{
    private readonly AppContext _context;

    public RepositoryBase(AppContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public void Delete(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
    }

    public TEntity Find(TKey id)
    {
        return _context.Set<TEntity>().Find(id);
    }

    public IEnumerable<TEntity> GetAll()
    {
        return _context.Set<TEntity>().AsEnumerable();
    }

    public void Insert(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
    }

    public void Update(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
    }
}
