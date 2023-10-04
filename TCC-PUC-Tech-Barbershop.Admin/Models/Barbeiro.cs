using System.ComponentModel.DataAnnotations.Schema;

namespace TCC_PUC_Tech_Barbershop.Admin.Models;

public class Barbeiro : Usuario
{
    public Agenda? Agenda { get; set; }
    public FormasPagamento? FormasAceitas { get; set; }
    [NotMapped]
    public List<Comentario> Comentarios { get; set; }
    [NotMapped]
    public List<Barbeiro> _barbeiros = new List<Barbeiro>();

    public Barbeiro()
    {
    }

    public Barbeiro(int id, string login, string senha, Contato contato, Informacao informacoes, Endereco endereco, TipoUsuarioEnum tipoUsuario) : base(id, login, senha, contato, informacoes, endereco, tipoUsuario)
    {
    }
}
