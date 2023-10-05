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

    public void AdicionarAtendimentos()
    {
        Atendimentos = new();
        Atendimentos.Add(new Atendimento(new DateTime(2023, 10, 01, 09, 00, 00), 1, 1, new Cliente(), new Barbeiro(1, "Barbeiro 1", "senha 1", new("(01) 23456-7890", "barb1@gmail.com"), new("Nome Barb1", "eiro1", "Desc1", "M"), new("88509-481", "SC", "", "rua1", "complemento", "bairro1", "Lags"), TipoUsuarioEnum.Barbeiro)));
        Atendimentos.Add(new Atendimento(new DateTime(2023, 10, 02, 10, 00, 00), 1, 1, new Cliente(), new Barbeiro(1, "Barbeiro 2", "senha 1", new("(02) 23456-7890", "barb2@gmail.com"), new("Nome Barb2", "eiro2", "Desc2", "M"), new("88509-481", "SC", "", "rua1", "complemento", "bairro1", "Lags"), TipoUsuarioEnum.Barbeiro)));
        Atendimentos.Add(new Atendimento(new DateTime(2023, 10, 03, 11, 00, 00), 1, 1, new Cliente(), new Barbeiro(1, "Barbeiro 3", "senha 1", new("(03) 23456-7890", "barb3@gmail.com"), new("Nome Barb3", "eiro3", "Desc3", "M"), new("88509-481", "SC", "", "rua1", "complemento", "bairro1", "Lags"), TipoUsuarioEnum.Barbeiro)));
        Atendimentos.Add(new Atendimento(new DateTime(2023, 10, 04, 02, 00, 00), 1, 1, new Cliente(), new Barbeiro(1, "Barbeiro 4", "senha 1", new("(04) 23456-7890", "barb4@gmail.com"), new("Nome Barb4", "eiro4", "Desc4", "M"), new("88509-481", "SC", "", "rua1", "complemento", "bairro1", "Lags"), TipoUsuarioEnum.Barbeiro)));
        Atendimentos.Add(new Atendimento(new DateTime(2023, 10, 05, 03, 00, 00), 1, 1, new Cliente(), new Barbeiro(1, "Barbeiro 5", "senha 1", new("(05) 23456-7890", "barb5@gmail.com"), new("Nome Barb5", "eiro5", "Desc5", "M"), new("88509-481", "SC", "", "rua1", "complemento", "bairro1", "Lags"), TipoUsuarioEnum.Barbeiro)));
        Atendimentos.Add(new Atendimento(new DateTime(2023, 10, 06, 04, 00, 00), 1, 1, new Cliente(), new Barbeiro(1, "Barbeiro 6", "senha 1", new("(06) 23456-7890", "barb6@gmail.com"), new("Nome Barb6", "eiro6", "Desc6", "M"), new("88509-481", "SC", "", "rua1", "complemento", "bairro1", "Lags"), TipoUsuarioEnum.Barbeiro)));
        Atendimentos.Add(new Atendimento(new DateTime(2023, 10, 07, 05, 00, 00), 1, 1, new Cliente(), new Barbeiro(1, "Barbeiro 7", "senha 1", new("(07) 23456-7890", "barb7@gmail.com"), new("Nome Barb7", "eiro7", "Desc7", "M"), new("88509-481", "SC", "", "rua1", "complemento", "bairro1", "Lags"), TipoUsuarioEnum.Barbeiro)));
    }
}
