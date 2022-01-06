using Dominio;
using EFContext.Repositorios;

namespace EFContext;

public class UnitOfWork : IUnitOfWork
{
    private bool _disposedValue;
    private readonly AppContext _appContext;

    public IPessoasRepository PessoasRepository { get; private set; }

    public UnitOfWork(AppContext appContext)
    {
        _appContext = appContext;

        PessoasRepository = new PessoaRepository(appContext);
    }

    public bool Commit()
    {
        try
        {
            _appContext.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                _appContext.Dispose();
            }

            // TODO: free unmanaged resources (unmanaged objects) and override finalizer
            // TODO: set large fields to null
            _disposedValue = true;
        }
    }

    // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
    // ~UnitOfWork()
    // {
    //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
    //     Dispose(disposing: false);
    // }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
