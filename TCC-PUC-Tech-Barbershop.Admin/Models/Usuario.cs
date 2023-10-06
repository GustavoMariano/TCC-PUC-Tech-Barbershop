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
        Atendimentos.Add(new Atendimento(1, new DateTime(2022, 10, 01, 09, 00, 00), 1, 1, new Usuario(1, "Cli1", "Senha", new("(01) 23456-7890", "Cli1@gmail.com"), new("Nome Cli1", "ente1", null, "M"), new("88509-481", "SC", "", "rua1", "complemento", "bairro1", "Lags"), TipoUsuarioEnum.Cliente), new Usuario(1, "Barbeiro 1", "senha 1", new("(01) 23456-7890", "barb1@gmail.com"), new("Nome Barb1", "eiro1", "Desc1", "M"), new("88509-481", "SC", "", "rua1", "complemento", "bairro1", "Lags"), TipoUsuarioEnum.Barbeiro)));
        Atendimentos.Add(new Atendimento(2, new DateTime(2022, 10, 02, 10, 00, 00), 2, 2, new Usuario(2, "Cli2", "Senha", new("(02) 23456-7890", "Cli2@gmail.com"), new("Nome Cli2", "ente2", null, "M"), new("88509-482", "SC", "", "rua2", "complemento", "bairro2", "Lags"), TipoUsuarioEnum.Cliente), new Usuario(2, "Barbeiro 2", "senha 1", new("(02) 23456-7890", "barb2@gmail.com"), new("Nome Barb2", "eiro2", "Desc2", "M"), new("88509-481", "SC", "", "rua1", "complemento", "bairro1", "Lags"), TipoUsuarioEnum.Barbeiro)));
        Atendimentos.Add(new Atendimento(3, new DateTime(2022, 10, 03, 11, 00, 00), 3, 3, new Usuario(3, "Cli3", "Senha", new("(03) 23456-7890", "Cli3@gmail.com"), new("Nome Cli3", "ente3", null, "M"), new("88509-483", "SC", "", "rua3", "complemento", "bairro3", "Lags"), TipoUsuarioEnum.Cliente), new Usuario(3, "Barbeiro 3", "senha 1", new("(03) 23456-7890", "barb3@gmail.com"), new("Nome Barb3", "eiro3", "Desc3", "M"), new("88509-481", "SC", "", "rua1", "complemento", "bairro1", "Lags"), TipoUsuarioEnum.Barbeiro)));
        Atendimentos.Add(new Atendimento(4, new DateTime(2024, 10, 04, 02, 00, 00), 4, 4, new Usuario(4, "Cli4", "Senha", new("(04) 23456-7890", "Cli4@gmail.com"), new("Nome Cli4", "ente4", null, "M"), new("88509-484", "SC", "", "rua4", "complemento", "bairro4", "Lags"), TipoUsuarioEnum.Cliente), new Usuario(4, "Barbeiro 4", "senha 1", new("(04) 23456-7890", "barb4@gmail.com"), new("Nome Barb4", "eiro4", "Desc4", "M"), new("88509-481", "SC", "", "rua1", "complemento", "bairro1", "Lags"), TipoUsuarioEnum.Barbeiro)));
        Atendimentos.Add(new Atendimento(5, new DateTime(2025, 10, 05, 03, 00, 00), 5, 5, new Usuario(5, "Cli5", "Senha", new("(05) 23456-7890", "Cli5@gmail.com"), new("Nome Cli5", "ente5", null, "M"), new("88509-485", "SC", "", "rua5", "complemento", "bairro5", "Lags"), TipoUsuarioEnum.Cliente), new Usuario(5, "Barbeiro 5", "senha 1", new("(05) 23456-7890", "barb5@gmail.com"), new("Nome Barb5", "eiro5", "Desc5", "M"), new("88509-481", "SC", "", "rua1", "complemento", "bairro1", "Lags"), TipoUsuarioEnum.Barbeiro)));
        Atendimentos.Add(new Atendimento(6, new DateTime(2026, 10, 06, 04, 00, 00), 6, 6, new Usuario(6, "Cli6", "Senha", new("(06) 23456-7890", "Cli6@gmail.com"), new("Nome Cli6", "ente6", null, "M"), new("88509-486", "SC", "", "rua6", "complemento", "bairro6", "Lags"), TipoUsuarioEnum.Cliente), new Usuario(6, "Barbeiro 6", "senha 1", new("(06) 23456-7890", "barb6@gmail.com"), new("Nome Barb6", "eiro6", "Desc6", "M"), new("88509-481", "SC", "", "rua1", "complemento", "bairro1", "Lags"), TipoUsuarioEnum.Barbeiro)));
        Atendimentos.Add(new Atendimento(7, new DateTime(2027, 10, 07, 05, 00, 00), 7, 7, new Usuario(7, "Cli7", "Senha", new("(07) 23456-7890", "Cli7@gmail.com"), new("Nome Cli7", "ente7", null, "M"), new("88509-487", "SC", "", "rua7", "complemento", "bairro7", "Lags"), TipoUsuarioEnum.Cliente), new Usuario(7, "Barbeiro 7", "senha 1", new("(07) 23456-7890", "barb7@gmail.com"), new("Nome Barb7", "eiro7", "Desc7", "M"), new("88509-481", "SC", "", "rua1", "complemento", "bairro1", "Lags"), TipoUsuarioEnum.Barbeiro)));
    }
}
