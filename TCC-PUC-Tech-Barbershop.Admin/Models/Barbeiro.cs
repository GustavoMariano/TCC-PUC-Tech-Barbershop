using System.ComponentModel.DataAnnotations.Schema;

namespace TCC_PUC_Tech_Barbershop.Admin.Models;

public class Barbeiro : Usuario
{
    public Barbeiro()
    {
    }

    public Barbeiro(int id, string login, string senha, Contato contato, Informacao informacoes, Endereco endereco, TipoUsuarioEnum tipoUsuario) : base(id, login, senha, contato, informacoes, endereco, tipoUsuario)
    {
    }
}
