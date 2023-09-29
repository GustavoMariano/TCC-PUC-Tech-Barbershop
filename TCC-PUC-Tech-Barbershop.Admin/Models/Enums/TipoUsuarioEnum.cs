using System.ComponentModel;

namespace TCC_PUC_Tech_Barbershop.Admin.Models;

public enum TipoUsuarioEnum
{
    [Description("Cliente")]
    Cliente = 0,

    [Description("Barbeiro")]
    Barbeiro = 1    
}
