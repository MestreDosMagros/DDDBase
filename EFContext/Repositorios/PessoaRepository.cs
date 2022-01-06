using Dominio;

namespace EFContext.Repositorios;

public class PessoaRepository : RepositoryBase<int, Pessoa>, IPessoasRepository
{
    public PessoaRepository(AppContext context) : base(context)
    {
    }
}
