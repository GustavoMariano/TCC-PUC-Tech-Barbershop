using System.ComponentModel.DataAnnotations;

namespace TCC_PUC_Tech_Barbershop.Admin.Models;

public class Endereco
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Campo obrigatório.")]
    public string Cep { get; set; }
    [Required(ErrorMessage = "Campo obrigatório.")]
    public string Estado { get; set; }
    [Required(ErrorMessage = "Campo obrigatório.")]
    public string Numero { get; set; }
    [Required(ErrorMessage = "Campo obrigatório.")]
    public string Logradouro { get; set; }
    public string Complemento { get; set; }
    [Required(ErrorMessage = "Campo obrigatório.")]
    public string Bairro { get; set; }
    [Required(ErrorMessage = "Campo obrigatório.")]
    public string Cidade { get; set; }

    public Endereco()
    {
    }

    public Endereco(string cep, string estado, string numero, string logradouro, string complemento, string bairro, string cidade)
    {
        Cep = cep;
        Estado = estado;
        Numero = numero;
        Logradouro = logradouro;
        Complemento = complemento;
        Bairro = bairro;
        Cidade = cidade;
    }
}
