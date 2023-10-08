using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCC_PUC_Tech_Barbershop.Admin.Models;

public class Usuario
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Campo obrigatório.")]
    public string Login { get; set; }
    [Required(ErrorMessage = "Campo obrigatório.")]
    public string Senha { get; set; }
    [Required(ErrorMessage = "Campo obrigatório.")]
    public byte[] Imagem { get; set; }
    [Required(ErrorMessage = "Campo obrigatório.")]
    public TipoUsuarioEnum TipoUsuario { get; set; }

    public Agenda? Agenda { get; set; }
    public List<FormasPagamento>? FormasAceitas { get; set; }
    public Contato Contato { get; set; }
    public Informacao Informacoes { get; set; }
    public Endereco Endereco { get; set; }

    public List<Atendimento> Atendimentos { get; set; }
    [NotMapped]
    public List<Usuario> Usuarios { get; set; }
    [NotMapped]
    public List<Comentario> Comentarios { get; set; }    
    
    public Usuario()
    {
    }

    public Usuario(int id, string login, string senha, Contato contato, Informacao informacoes, Endereco endereco, TipoUsuarioEnum tipoUsuario)
    {
        Id = id;
        Login = login;
        Senha = senha;
        Contato = contato;
        Informacoes = informacoes;
        Endereco = endereco;
        this.TipoUsuario = tipoUsuario;
    }

    public void SetarAgenda()
    {

    }

    public void SetarFormasPagamento()
    {

    }
}
