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

    public string? FormasPagamentos { get; set; }
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
}
