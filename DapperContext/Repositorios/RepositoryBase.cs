using Dominio;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace DapperContext.Repositorios;

public abstract class RepositoryBase<TKey, TEntity> : IRepositoryBase<TKey, TEntity> where TEntity : Base<TKey>
{
    protected OracleTransaction? _transaction;
    protected readonly OracleConnection _connection;

    public RepositoryBase(IConfiguration configuration)
    {
        _connection = new OracleConnection(configuration.GetConnectionString("Oracle"));
    }

    public abstract void Insert(TEntity entity);
    public abstract void Update(TEntity entity);
    public abstract void Delete(TEntity entity);
    public abstract TEntity Find(TKey id);
    public abstract IEnumerable<TEntity> GetAll();

    public void BeginTransaction()
    {
        _connection.Open();
        _transaction = _connection?.BeginTransaction();
    }

    public void Commit()
    {
        _transaction?.Commit();
    }

    public void Rollback()
    {
        _transaction?.Rollback();
    }
}
