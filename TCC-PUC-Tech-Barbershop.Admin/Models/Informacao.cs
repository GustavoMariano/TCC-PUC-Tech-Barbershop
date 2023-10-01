namespace TCC_PUC_Tech_Barbershop.Admin.Models;

public class Informacao
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public string Descricao { get; set; }
    public string Sexo { get; set; }

    public Informacao()
    {
    }

    public Informacao(string nome, string sobrenome, string descricao, string sexo)
    {
        Nome = nome;
        Sobrenome = sobrenome;
        Descricao = descricao;
        Sexo = sexo;
    }
}
