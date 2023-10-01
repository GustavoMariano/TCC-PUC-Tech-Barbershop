namespace TCC_PUC_Tech_Barbershop.Admin.Models;

public class Usuario
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Senha { get; set; }    
    public Contato Contato { get; set; }
    public Informacoes Informacoes { get; set; }
    public Endereco Endereco { get; set; }
    public TipoUsuarioEnum TipoUsuario { get; set; }

    public List<Usuario> Usuarios { get; set; }
    public List<Barbeiro> Barbeiros { get; set;}

    public Usuario()
    {
    }

    public Usuario(int id, string login, string senha, Contato contato, Informacoes informacoes, Endereco endereco, TipoUsuarioEnum tipoUsuario)
    {
        Id = id;
        Login = login;
        Senha = senha;
        Contato = contato;
        Informacoes = informacoes;
        Endereco = endereco;
        this.TipoUsuario = tipoUsuario;
    }

    public void AdicionarBarbeiros()
    {
        Barbeiros = new List<Barbeiro>();
        Barbeiros.Add(new Barbeiro(1, "Barbeiro 1", "senha 1", null, new("Barb1", "eiro1", "Desc1", "M"), new("88509-481", "SC", "", "rua1", "complemento", "bairro1", "Lags"), TipoUsuarioEnum.Barbeiro));
        Barbeiros.Add(new Barbeiro(2, "Barbeiro 2", "senha 2", null, new("Barb2", "eiro2", "Desc2", "M"), new("88509-482", "SC", "", "rua2", "complemento", "bairro2", "Lags"), TipoUsuarioEnum.Barbeiro));
        Barbeiros.Add(new Barbeiro(3, "Barbeiro 3", "senha 3", null, new("Barb3", "eiro3", "Desc3", "M"), new("88509-483", "SC", "", "rua3", "complemento", "bairro3", "Lags"), TipoUsuarioEnum.Barbeiro));
        Barbeiros.Add(new Barbeiro(4, "Barbeiro 4", "senha 4", null, new("Barb4", "eiro4", "Desc4", "M"), new("88509-484", "SC", "", "rua4", "complemento", "bairro4", "Lags"), TipoUsuarioEnum.Barbeiro));
        Barbeiros.Add(new Barbeiro(5, "Barbeiro 5", "senha 5", null, new("Barb5", "eiro5", "Desc5", "M"), new("88509-485", "SC", "", "rua5", "complemento", "bairro5", "Lags"), TipoUsuarioEnum.Barbeiro));
        Barbeiros.Add(new Barbeiro(6, "Barbeiro 6", "senha 6", null, new("Barb6", "eiro6", "Desc6", "M"), new("88509-486", "SC", "", "rua6", "complemento", "bairro6", "Lags"), TipoUsuarioEnum.Barbeiro));
        Barbeiros.Add(new Barbeiro(7, "Barbeiro 7", "senha 7", null, new("Barb7", "eiro7", "Desc7", "M"), new("88509-487", "SC", "", "rua7", "complemento", "bairro7", "Lags"), TipoUsuarioEnum.Barbeiro));
    }
}
