using TCC_PUC_Tech_Barbershop.Admin.Models;

namespace TCC_PUC_Tech_Barbershop.Admin.Repositories;

public class UsuarioRepository
{
    public static Usuario Get(string login, string senha)
    {
        var users = new List<Usuario>();
        users.Add(new Usuario { Id = 1, Login = "batman", Senha = "batman", TipoUsuario = TipoUsuarioEnum.Barbeiro });
        users.Add(new Usuario { Id = 2, Login = "robin", Senha = "robin", TipoUsuario = TipoUsuarioEnum.Cliente });
        return users.Where(x => x.Login.ToLower() == login.ToLower() && x.Senha == x.Senha).FirstOrDefault();
    }
}
