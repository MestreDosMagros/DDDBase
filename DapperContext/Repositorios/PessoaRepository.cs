using Dapper;
using Dominio;
using Microsoft.Extensions.Configuration;

namespace DapperContext.Repositorios;

public class PessoaRepository : RepositoryBase<int, Pessoa>, IPessoasRepository
{
    public PessoaRepository(IConfiguration configuration) : base(configuration)
    {
    }

    public override void Delete(Pessoa entity)
    {
        throw new NotImplementedException();
    }

    public override Pessoa Find(int id)
    {
        return _connection.QuerySingle<Pessoa>(
            @"SELECT 
                ID, 
                NOME, 
                SOBRENOME, 
                DOCUMENTO, 
                DATANASCIMENTO 
            FROM PESSOAS
           WHERE ID = :ID", new { id });
    }

    public override IEnumerable<Pessoa> GetAll()
    {
        return _connection.Query<Pessoa>(
            @"SELECT 
                ID, 
                NOME, 
                SOBRENOME, 
                DOCUMENTO, 
                DATANASCIMENTO 
            FROM PESSOAS");
    }

    public override void Insert(Pessoa entity)
    {
        _connection.Execute(
            @"INSERT INTO PESSOAS 
                (ID, NOME, SOBRENOME, DOCUMENTO, DATANASCIMENTO) 
              VALUES 
                (:ID, :NOME, :SOBRENOME, :DOCUMENTO, :DATANASCIMENTO)", entity);
        /*
         * new { 
                ID = entity.Id,
                NOME = entity.Nome,
                SOBRENOME = entity.Sobrenome,
                DOCUMENTO = entity.Documento,
                DATANASCIMENTO = entity.DataNascimento
            }
         * */
    }

    public override void Update(Pessoa entity)
    {
        throw new NotImplementedException();
    }
}
