namespace Dominio;

public interface IUnitOfWork : IDisposable
{
    IPessoasRepository PessoasRepository { get; }

    public bool Commit();
}
