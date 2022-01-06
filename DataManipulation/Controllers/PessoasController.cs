using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace DataManipulation.Controllers;

[ApiController, Route("[controller]")]
public class PessoasController : ControllerBase
{
    private readonly IPessoasRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public PessoasController(IPessoasRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        
        _unitOfWork = unitOfWork;
    }

    [HttpPost]
    public IActionResult Create(Pessoa pessoa)
    {
        //_repository.Insert(pessoa);

        _unitOfWork.PessoasRepository.Insert(pessoa);
        _unitOfWork.Commit();

        return Ok("Criado com sucesso!");
    }

    [HttpPut, Route("{id}")]
    public IActionResult Update(int id, Pessoa pessoa)
    {
        _repository.Update(pessoa);
        return Ok("Atualizado com sucesso!");
    }

    [HttpDelete, Route("{id}")]
    public IActionResult Delete(int id)
    {
        var pessoa = _repository.Find(id);
        _repository.Delete(pessoa);
        return Ok("Deletado com sucesso!");
    }

    [HttpGet, Route("{id}")]
    public IActionResult Get(int id)
    {
        return Ok(_repository.Find(id));
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_repository.GetAll());
    }
}
