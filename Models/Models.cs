using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models;

public class Pessoa : BaseModel
{
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public string Documento { get; set; }
    public DateTime DataNascimento { get; set; }
}

public class BaseModel
{
    public int Id { get; set; }
}

