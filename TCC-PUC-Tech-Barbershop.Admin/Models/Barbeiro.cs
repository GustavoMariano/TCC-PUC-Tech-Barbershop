using System.ComponentModel.DataAnnotations.Schema;

namespace TCC_PUC_Tech_Barbershop.Admin.Models;

public class Barbeiro : Usuario
{
    public Agenda Agenda { get; set; }
    public FormasPagamento FormasAceitas { get; set; }
    [NotMapped]
    public List<Comentario> Comentarios { get; set; }
    [NotMapped]
    public List<Atendimento> Atendimentos { get; set; }
    [NotMapped]
    public List<Barbeiro> _barbeiros = new List<Barbeiro>();

    //public Barbeiro(string login, string senha, Contato contato, Informacoes informacoes, Endereco endereco, TipoUsuarioEnum tipoUsuario) : base(login, senha, contato, informacoes, endereco, tipoUsuario)
    //{
    //}

    public Barbeiro()
    {

    }

    public Barbeiro(int id, string login, string senha, Contato contato, Informacao informacoes, Endereco endereco, TipoUsuarioEnum tipoUsuario) : base(id, login, senha, contato, informacoes, endereco, tipoUsuario)
    {
    }
}
