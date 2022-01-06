namespace Dominio;

public interface IRepositoryBase<TKey, TEntity> where TEntity : Base<TKey>
{
    public void Insert(TEntity entity);
    public void Update(TEntity entity);
    public void Delete(TEntity entity);
    public TEntity Find(TKey id);
    public IEnumerable<TEntity> GetAll();
}
