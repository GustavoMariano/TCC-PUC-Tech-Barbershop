using System.ComponentModel;

namespace TCC_PUC_Tech_Barbershop.Admin.Models.Enums;

public enum FormaPagamentoEnum
{
    [Description("Pix")]
    Pix = 0,

    [Description("Cartão")]
    Cartao = 1,

    [Description("Dinheiro")]
    Dinheiro = 2
}
