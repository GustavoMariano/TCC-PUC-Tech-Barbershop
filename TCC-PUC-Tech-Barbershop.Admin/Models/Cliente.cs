namespace TCC_PUC_Tech_Barbershop.Admin.Models;

public class Cliente : Usuario
{
    public Cliente(string login, string senha, Contato contato, Informacoes informacoes, Endereco endereco, TipoUsuarioEnum tipoUsuario) : base(login, senha, contato, informacoes, endereco, tipoUsuario)
    {
    }
}
