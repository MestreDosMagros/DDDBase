namespace Dominio;

public class Pessoa : Base<int>
{
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public string Documento { get; set; }
    public DateTime DataNascimento { get; set; }
}
