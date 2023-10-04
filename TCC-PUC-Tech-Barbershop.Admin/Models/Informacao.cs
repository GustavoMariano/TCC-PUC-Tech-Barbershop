using System.ComponentModel.DataAnnotations;

namespace TCC_PUC_Tech_Barbershop.Admin.Models;

public class Informacao
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Campo obrigatório.")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "Campo obrigatório.")]
    public string Sobrenome { get; set; }
    [Required(ErrorMessage = "Campo obrigatório.")]
    public string Sexo { get; set; }
    public string? Descricao { get; set; }

    public Informacao()
    {
    }

    public Informacao(string nome, string sobrenome, string? descricao, string sexo)
    {
        Nome = nome;
        Sobrenome = sobrenome;
        Sexo = sexo;
        Descricao = descricao;
    }
}
